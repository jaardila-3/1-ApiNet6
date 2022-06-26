document.addEventListener("DOMContentLoaded", init);
const URL_API = 'https://localhost:7014/api/'

var customers = []

function init() {
  search()
}

function agregar() {
  clean()
  abrirFormulario()
}

function abrirFormulario() {
  htmlModal = document.getElementById("modal");
  htmlModal.setAttribute("class", "modale opened");
}

function cerrarModal() {
  htmlModal = document.getElementById("modal");
  htmlModal.setAttribute("class", "modale");
}


async function search() {
  var url = URL_API + 'customer'
  var response = await fetch(url, {
    "method": 'GET',
    "headers": {
      "Content-Type": 'application/json'
    }
  })
  customers = await response.json();

  var html = ''
  for (customer of customers) {
    var row = `<tr>
    <td>${customer.firstName}</td>
    <td>${customer.lastName}</td>
    <td>${customer.email}</td>
    <td>${customer.phone}</td>
    <td>
      <a href="#" onclick="edit(${customer.id})" class="btnEdit">Editar</a>
      <a href="#" onclick="remove(${customer.id})" class="btnDelete">Eliminar</a>
    </td>
  </tr>`
    html = html + row;
  }
  document.querySelector('#customers > tbody').outerHTML = html
}

async function edit(id){
  abrirFormulario();
  var customer = customers.find(x=>x.id==id);
  document.getElementById('txtId').value = customer.id;
  document.getElementById('txtFirstname').value = customer.firstName;
  document.getElementById('txtLastname').value = customer.lastName;
  document.getElementById('txtPhone').value = customer.phone;
  document.getElementById('txtAddress').value = customer.address;
  document.getElementById('txtEmail').value = customer.email;
}

async function remove(id) {
  respuesta = confirm('¿Está seguro de eliminarlo?')
  if (respuesta) {
    var url = URL_API + 'customer/' + id
    await fetch(url, {
      "method": 'DELETE',
      "headers": {
        "Content-Type": 'application/json'
      }
    })
    window.location.reload();
  }
}

function clean() {
  document.getElementById('txtId').value = '';
  document.getElementById('txtFirstname').value = '';
  document.getElementById('txtLastname').value = '';
  document.getElementById('txtPhone').value = '';
  document.getElementById('txtAddress').value = '';
  document.getElementById('txtEmail').value = '';
}

async function save() {
  var data = {
    "address": document.getElementById('txtAddress').value,
    "email": document.getElementById('txtEmail').value,
    "firstName": document.getElementById('txtFirstname').value,
    "lastName": document.getElementById('txtLastname').value,
    "phone": document.getElementById('txtPhone').value
  }

  var id = document.getElementById('txtId').value
  if (id != '') {
    data.id = id
  }

  var url = URL_API + 'customer'
  await fetch(url, {
    "method": id != '' ? 'PUT' : 'POST',
    "body": JSON.stringify(data),
    "headers": {
      "Content-Type": 'application/json'
    }
  })
  window.location.reload();
}