/*
const apiURL = 'http://localhost:5246/api/libros';

async function getlibros (){
  try{
    const response = await fetch (apiURL);
    const libros = await response.json();

    console.log(libros);
  }catch (error){
     console.error;
  }
}

getlibros();
*/

let url = 'http://localhost:5246/api/librosAutor';
fetch(url)
    .then(response => response.json())
    .then(data => mostrarData(data))
    .catch(error => console.log(error))

const mostrarData = (data) => {
  console.log(data)
  let body = ''
  for(let i = 0; i < data.length; i++){
    body += `<tr>
                 <td>${data[i].title}</td>
                 <td>${data[i].authorName}</td>
                 <td>${data[i].chapters}</td>
                 <td>${data[i].pages}</td>
                 <td>$${data[i].price}</td>
                 </tr>`
  }

  document.getElementById('data').innerHTML = body
}