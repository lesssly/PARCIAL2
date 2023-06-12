<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="./css/estilos.css" rel="stylesheet" type="text/css" />
    <title>Document</title>
</head>

<body >
    
<header class="header-area header-sticky">
    <div class="container">
      <div class="row">
        <div class="col-12">
          <nav class="main-nav">
            <!-- ***** Logo Start ***** -->
            <a href="index.php" class="logo">
              <img src="./img/escudo.png" alt="" style="max-width: 120px;">
             
            <h1>PROCESO DE INSCRIPCION CENTRO DE ESTUDIANTES DE INFORMATICA </h1>
   

            </a>
            
          </nav>
        </div>
      </div>
    </div>
  </header>

  
    <div class="formulario">
    

        
        <h2 style="color:aliceblue;">INGRESAR</h2>
        <form action="controlindex.php" method="GET">
            <div style="width:80%; margin: 20px auto">
                <div class="borde">
                    <div class="alineacion">
                        <div class="img">
                            <img style="width:50px;" src="./img/usuario.png" />
                        </div>
                        <input type="text" name="usuario" value="" placeholder="Usuario CI" required>
                    </div>
                </div>

                <div class="borde">
                    <div class="alineacion">
                        <div class="img">
                            <img style="width:50px;" src="./img/passwd.png" />
                        </div>
                        <input type="password" name="contrasenia" value="" placeholder="Password" required>
                    </div>
                </div>
                <br>
                <button type="submit" class="boton1">
                    VALIDAR
                </button>
            </div>
        </form>
    </div>
</body>

</html>