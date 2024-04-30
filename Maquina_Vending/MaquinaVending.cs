using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina_Vending
{
    internal class MaquinaVending
    {
        public List<Producto> listaProductos;

        public MaquinaVending(List<Producto> productos)
        {
            listaProductos = productos;
        }
        public void ComprarProdcuto()
        {
            MostrarProductosDisponibles();
            Console.Write("Ingrese el ID del producto que desea comprar: ");
            int idProducto = int.Parse(Console.ReadLine());
            // Buscar el producto en la lista de productos disponibles
            Producto productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

            //Verificar si el producto existe
            if (productoSeleccionado != null)
            {
                if (productoSeleccionado.Unidades > 0)
                {
                    Console.Clear();
                    // Mostrar la información del producto seleccionado
                    Console.WriteLine("Información del producto seleccionado:\n");
                    productoSeleccionado.MostrarInformacion();

                    // Solicitar al usuario que elija el método de pago
                    Console.WriteLine("Seleccione el método de pago:");
                    Console.WriteLine("1. Pago en efectivo");
                    Console.WriteLine("2. Pago con tarjeta");
                    Console.Write("Elija una opción: ");
                    int opcion = int.Parse(Console.ReadLine());
                    try
                    {
                        switch (opcion)
                        {
                            case 1:
                                if (PagoEfectivo(productoSeleccionado))
                                {
                                    productoSeleccionado.Unidades = productoSeleccionado.Unidades - 1; // Disminuir las unidades del producto
                                    Console.WriteLine("¡Compra exitosa! Reciba su producto.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("El pago en efectivo no fue suficiente.");
                                    return;
                                }
                            case 2:
                                if (PagoTarjeta())
                                {
                                    Console.WriteLine("¡Compra exitosa! Reciba su producto.");
                                    productoSeleccionado.Unidades = productoSeleccionado.Unidades - 1; // Disminuir las unidades del producto
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("El pago con tarjeta fue rechazado.");
                                    return;
                                }
                            case 3:
                                Console.WriteLine("Saliendo...");
                                break;
                            default:
                                Console.WriteLine("Opción de pago no válida.");
                                break;
                        } while (opcion != 3) ;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Opción invalida. Por favor, ingrese un número válido.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("El producto está agotado.");
                }
            }
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
        }


        public void MostrarProductosDisponibles()
        {
            Console.WriteLine("Productos disponibles:");
            foreach (Producto producto in listaProductos)
            {
                Console.WriteLine($"{producto.Id}: {producto.Nombre}");
            }
        }
        private bool PagoEfectivo(Producto producto)
        {
            Console.WriteLine($"El precio del producto es: {producto.PrecioUnidad}");
            float montoRestante = producto.PrecioUnidad;

            Console.WriteLine($"Por favor, ingrese el monto en efectivo (puede usar billetes de 5, 10, 20, 50 y 100 euros, y monedas de 1 y 2 euros):");

            while (montoRestante > 0)
            {
                Console.WriteLine($"Monto restante: {montoRestante}euros");
                Console.Write("Ingrese una moneda o billete: ");

                if (float.TryParse(Console.ReadLine(), out float monto))
                {
                    if (monto == 1 || monto == 2 || monto == 5 || monto == 10 || monto == 20 || monto == 50 || monto == 100)
                    {
                        montoRestante -= monto;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingrese una moneda o billete válido.");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un valor numérico válido.");
                }
            }

            Console.WriteLine("¡Pago exitoso! Gracias por su compra.");
            return true;
        }

        private bool PagoTarjeta()
        {
            Console.WriteLine("Ingrese los datos de su tarjeta:");
            Console.Write("Número de tarjeta: ");
            string numeroTarjeta = Console.ReadLine();
            Console.Write("Fecha de caducidad (MM/AA): ");
            string fechaCaducidad = Console.ReadLine();
            Console.Write("Código de seguridad: ");
            string codigoSeguridad = Console.ReadLine();

            // Supongamos que siempre aceptamos el pago con tarjeta
            return true;
        }

        public void MostrarInformacionProducto()
        {
            // Mostrar los productos disponibles
            MostrarProductosDisponibles();

            // Solicitar al usuario que ingrese el ID del producto del que desea ver la información
            Console.Write("Ingrese el ID del producto del que desea ver la información: ");
            int idProducto = int.Parse(Console.ReadLine());

            // Buscar el producto en la lista de productos disponibles
            Producto productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

            // Verificar si el producto existe
            if (productoSeleccionado != null)
            {
                // Mostrar la información del producto seleccionado
                Console.WriteLine("Información del producto seleccionado:");
                productoSeleccionado.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
        }

        public void CargarProductosIndividualmente()
        {

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1.- Añadir existencias a un producto existente");
                Console.WriteLine("2.- Añadir un nuevo producto a las ranuras disponibles");
                Console.WriteLine("3.- Reducir las unidades de un producto a 0");
                Console.WriteLine("4.- salir");
                Console.WriteLine("Opción: ");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            MostrarProductosDisponibles();
                            int idTemp = int.Parse(Console.ReadLine());
                            Producto productoTemp = null;
                            foreach (Producto producto in listaProductos)
                            {
                                if (producto.Id == idTemp)
                                { 
                                    productoTemp = producto;
                                }
                            }
                            if(productoTemp != null)
                            {
                                Console.WriteLine("Existencias:");
                                int existencias = int.Parse(Console.ReadLine());
                                productoTemp.Unidades = productoTemp.Unidades + existencias;
                            }
                            else
                            {
                                Console.WriteLine("Id no encontrado");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Seleccione el tipo de producto:");
                            Console.WriteLine("1. Materiales preciosos");
                            Console.WriteLine("2. Productos alimenticios");
                            Console.WriteLine("3. Productos electrónicos");
                            Console.Write("Elija una opción: ");
                            if (listaProductos.Count < 12)
                            {
                                int opcionTipo = int.Parse(Console.ReadLine());


                                switch (opcionTipo)
                                {
                                    case 1:
                                        MaterialPrecioso materialPrecioso= new MaterialPrecioso(listaProductos.Count);
                                        materialPrecioso.SolicitarInformación();
                                        listaProductos.Add(materialPrecioso);
                                        break;

                                    case 2:
                                        ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio(listaProductos.Count);
                                        productoAlimenticio.SolicitarInformación();
                                        listaProductos.Add(productoAlimenticio);
                                        break;
                                    case 3:
                                        ProductoElectronico productoElectrónico = new ProductoElectronico(listaProductos.Count);
                                        productoElectrónico.SolicitarInformación();
                                        listaProductos.Add(productoElectrónico);
                                        break;

                                    default:
                                        Console.WriteLine("Opción no válida.");
                                        return;
                                }

                                // Agregar el nuevo producto a la lista de productos
                                Console.WriteLine("Producto agregado correctamente.");
                            }
                            
                            break;  
                            
                        case 3:

                            ReducirUnidadesProducto();
                            break;

                        case 4:
                            
                            break;


                        default:
                            Console.WriteLine("Opción no valida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Opción invalida. Por favor, ingrese un número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            } while (opcion != 3);


            
        }

        public void CargarProductosDesdeArchivo()
        {

            Console.WriteLine("Introduce el nombre del archivo:");
            string nombreFichero = Console.ReadLine();
            try
            {
                if (File.Exists(nombreFichero))
                {
                    // Leer el archivo CSV línea por línea
                    StreamReader reader = new StreamReader(nombreFichero);
                    {
                        string linea;
                        while ((linea = reader.ReadLine()) != null)
                        {
                            // Dividir la línea en sus campos utilizando el delimitador ";"
                            string[] campos = linea.Split(';');
                            if(listaProductos.Count < 12)
                            {
                                // Extraer los datos de cada campo
                                string tipoProducto = campos[0];
                                string nombre = campos[1];
                                string unidades = campos[2];
                                float precioUnidad = float.Parse(campos[3]);
                                string descripcion = campos[4];

                                // Crear una instancia del tipo de producto adecuado según el valor de tipoProducto
                                switch (tipoProducto)
                                {
                                    case "1":
                                        string material = campos[5];
                                        double peso = double.Parse(campos[6].Replace("g", ""));
                                        MaterialPrecioso materialPrecioso = new MaterialPrecioso(listaProductos.Count, nombre, int.Parse(unidades), precioUnidad, descripcion, material, peso);
                                        listaProductos.Add(materialPrecioso);
                                        break;

                                    case "2":
                                        string informacionNutricional = campos[7];
                                        ProductoAlimenticio productoAlimenticio = new ProductoAlimenticio(listaProductos.Count, nombre, int.Parse(unidades), precioUnidad, descripcion, informacionNutricional);
                                        listaProductos.Add(productoAlimenticio);
                                        break;

                                    case "3":
                                        string materialesUtilizados = campos[5];
                                        bool tienePilas = campos[8] == "1";
                                        bool estaPrecargado = campos[9] == "1";
                                        ProductoElectronico productoElectrónico = new ProductoElectronico(listaProductos.Count, nombre, int.Parse(unidades), precioUnidad, descripcion, materialesUtilizados, tienePilas, estaPrecargado);
                                        listaProductos.Add(productoElectrónico);
                                        break;

                                    default:
                                        Console.WriteLine($"Tipo de producto no válido en la línea: {linea}");
                                        continue; // Pasar a la siguiente línea del archivo
                                }
                                // Agregar el nuevo producto a la lista de productos
                                Console.WriteLine($"Producto {campos[1]} cargado desde el archivo correctamente.");
                            }
                            else
                            {
                                Console.WriteLine($"Ya hay 12 elementos en la máquina, no se ha podido cargar el producto con nombre: {campos[1]}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No se encuentra el archivo");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo '{nombreFichero}' no se encontró.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar productos desde el archivo: {ex.Message}");
            }
        }


        public void ReducirUnidadesProducto()
        {
            MostrarProductosDisponibles();
            Console.Write("Ingrese el ID del producto del que desea reducir las unidades a 0: ");
            int idProducto = int.Parse(Console.ReadLine());

            // Buscar el producto en la lista de productos disponibles
            Producto productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

            // Verificar si el producto existe
            if (productoSeleccionado != null)
            {
                productoSeleccionado.Unidades = 0;
                Console.WriteLine("Unidades del producto reducidas a 0 exitosamente.");
            }
            else
            {
                Console.WriteLine("El producto no está disponible.");
            }
        }


    }
}
