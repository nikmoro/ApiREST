const datos = async () => {
    
    let donacion = "";
    let idTabla = document.getElementById("donacion");
    
    try {
        const dato = await fetch("http://www.apidonaciones.somee.com/api/Donacion", {method : "GET"});
        // console.log(dato);
        const respuesta = await dato.json();
        // console.log(respuesta[1].id);

        respuesta.forEach((elemento) => {
            donacion += `<tr>
                            <td>${elemento.id}</td>
                            <td style="text-align:center;">${elemento.nombre_mpio}</td>
                            <td style="text-align:center;">${elemento.nombre_arbol}</td>
                            <td style="text-align:center;">${elemento.cantidad}</td>
                        </tr>`
        });

    } catch (error) {
        
    }

    idTabla.innerHTML = donacion;
}

let idBtn = document.getElementById("recargar");
idBtn.addEventListener("click", e => {
    datos();   
});