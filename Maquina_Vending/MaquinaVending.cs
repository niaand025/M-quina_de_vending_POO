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



        public void ComprarProdcuto(Usuario usuario)
        {
            MostrarProductosDisponibles();
            Console.Write("Ingrese el ID del producto que desea comprar: ");
            int idProducto = int.Parse(Console.ReadLine());
            // Buscar el producto en la lista de productos disponibles
            Producto productoSeleccionado = listaProductos.FirstOrDefault(p => p.Id == idProducto);

            //Verificar si el  prodcuto existe
            if (productoSeleccionado != null)
            {
                // Mostrar la información del producto seleccionado
                Console.WriteLine("Información del producto seleccionado:");
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
                                Console.WriteLine("¡Compra exitosa! Reciba su producto.");
                                productoSeleccionado.Unidades--; // Disminuir las unidades del producto
                            }
                            else
                            {
                                Console.WriteLine("El pago en efectivo no fue suficiente.");
                            }
                            break;
                        case 2:
                            if (PagoTarjeta())
                            {
                                Console.WriteLine("¡Compra exitosa! Reciba su producto.");
                                productoSeleccionado.Unidades--; // Disminuir las unidades del producto
                            }
                            else
                            {
                                Console.WriteLine("El pago con tarjeta fue rechazado.");
                            }
                            break;
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
            Console.WriteLine("Por favor, ingrese el monto en efectivo:");

            double montoIngresado = 0;
            while (montoIngresado < producto.PrecioUnidad)
            {
                Console.Write("Ingrese una moneda: ");
                double moneda = double.Parse(Console.ReadLine());
                montoIngresado += moneda;
            }

            return montoIngresado >= producto.PrecioUnidad;
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
                Console.WriteLine("3.- salir");
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
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 3);


            
        }

        public void CargarProductosDesdeArchivo(string archivo)
        {
            try
            {
                // Leer el archivo CSV línea por línea
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        // Dividir la línea en sus campos utilizando el delimitador ";"
                        string[] campos = linea.Split(';');

                        // Extraer los datos de cada campo
                        int id = int.Parse(campos[0]);
                        string nombre = campos[1];
                        int unidades = int.Parse(campos[2]);
                        float precioUnidad = float.Parse(campos[3]);
                        string descripcion = campos[4];
                        int tipoProducto = int.Parse(campos[5]);

                        // Crear una instancia del tipo de producto adecuado según el valor de tipoProducto
                        Producto nuevoProducto = null;
                        switch (tipoProducto)
                        {
                            case 1:
                                string material = campos[6];
                                double peso = double.Parse(campos[7]);
                                nuevoProducto = new MaterialPrecioso(id, nombre, unidades, precioUnidad, descripcion, material, peso);
                                break;

                            case 2:
                                string informacionNutricional = campos[6];
                                nuevoProducto = new ProductoAlimenticio(id, nombre, unidades, precioUnidad, descripcion, informacionNutricional);
                                break;

                            case 3:
                                string materialesUtilizados = campos[6];
                                bool tienePilas = campos[7].ToLower() == "si";
                                bool estaPrecargado = campos[8].ToLower() == "si";
                                nuevoProducto = new ProductoElectronico(id, nombre, unidades, precioUnidad, descripcion, materialesUtilizados, tienePilas, estaPrecargado);
                                break;

                            default:
                                Console.WriteLine($"Tipo de producto no válido en la línea: {linea}");
                                continue; // Pasar a la siguiente línea del archivo
                        }

                        // Agregar el nuevo producto a la lista de productos
                        listaProductos.Add(nuevoProducto);
                    }
                }

                Console.WriteLine("Productos cargados desde el archivo correctamente.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo '{archivo}' no se encontró.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar productos desde el archivo: {ex.Message}");
            }
        }

    }
}
