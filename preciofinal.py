print("Bienvenido dinos los precio, ganncia y impuesto")
#escribir  leer 
precio =  input("engrese el precio: ")
precio = float(precio)
ganacia =  input("engrese el ganancia: ")
ganacia = float(ganacia)
impuesto =  input("engrese el impuesto: ")
impuesto = float(impuesto)
#funcion nombre de l avariable()
def calcularImpuesto(impuesto, precio):
    return impuesto * precio
def calcularGanancia(ganacia, precio):
    return ganacia * precio

def calcularPrecioFinal(precio, impuesto, ganancia):
    precio1 = calcularGanancia(ganacia, precio) + precio
    impuestVenta = calcularImpuesto(impuesto, precio1)
    return precio1 + impuestVenta

print(calcularPrecioFinal(precio, impuesto, ganancia))