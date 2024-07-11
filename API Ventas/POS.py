from flask import Flask, request, jsonify
from flask_restful import Resource, Api
from flask_cors import CORS
import requests, time

app = Flask(__name__)
api = Api(app)
cors = CORS(app, resources={r"/api/*": {"origins": "*"}})

documentos = []

class BE(Resource):
    def post(self):
        body = request.get_json()
        response = requests.get("http://localhost:27776/api/cliente/%s" % body['client'])
        cliente = response.json()
        productos = []
        total = 0
        for x in body['products']:
            response = requests.get("http://localhost:27776/api/producto/%s" % x['id'])
            product = response.json()
            if product['stock'] >= int(x['quantity']):
                product['quantity'] = int(x['quantity'])
                total += (product['price']*int(x['quantity']))
                productos.append(product)
            else:
                return {'message': "Stock insuficiente del producto: %s, stock disponible: %d" % (product['name'], product['stock']) }, 404
        for x in productos:
            response = requests.put("http://localhost:27776/api/producto/%s/reducirstock" % x['id'], json=x['quantity'])
        data = {
            'documento': body['documento'],
            'cliente': cliente,
            'productos': productos,
            'total': total,
            'metodoPago': body['metodoPago'],
            'id': str(len(documentos)+1).zfill(6)
        }
        documentos.append(data)
        return data
    
    def get(self, boleta_id):
        boleta = next((obj for obj in documentos if obj['id'] == boleta_id), None)
        return boleta

class ProcessPayment(Resource):
    def post(self):
        time.sleep(5)
        success = True
        if success:
            mensaje = "Pago validado correctamente."
        else:
            mensaje = "Hubo un problema al validar el pago. Inténtalo de nuevo."
        return jsonify({'message': mensaje})

api.add_resource(BE, '/api/BE', '/api/BE/<string:boleta_id>')
api.add_resource(ProcessPayment, '/api/payment')

if __name__ == '__main__':
    app.run(debug=True)