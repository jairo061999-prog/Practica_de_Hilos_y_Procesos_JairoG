Introducción al desarrollo con hilos y procesos

Programas de consola en C# (.NET) de la actividad T01.

Qué hace | Cómo ejecutarlo |

Reto1_MiPrimerHilo | Hilo que cuenta del 1 al 5 mientras Main escribe su mensaje | `dotnet run` o `dotnet run -- join-ya` |

Reto2_CondicionCarrera | Dos hilos suman a una variable compartida (sin protección, lock, Interlocked) | `dotnet run` o `dotnet run -- 1000000` |

Reto3_TareasYTiempo | Tres descargas simuladas, en serie y con Task.WhenAll, midiendo el tiempo | `dotnet run` |

Reto4_LanzarProceso | Lanza `dotnet --version` y un programa que no existe | `dotnet run` |

Se ejecuta desde dentro de cada carpeta, por ejemplo:

```
cd Reto1_MiPrimerHilo
dotnet run
```
