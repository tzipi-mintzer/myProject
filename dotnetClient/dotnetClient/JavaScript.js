function get()
{
  fetch(`https://localhost:44341/api/Role`).then(res=>
  {res.json().then(data=>
    {document.getElementById("d1").innerHTML+=JSON.stringify(data)})});

    // fetch(`https://localhost:44341/api/Role`).then(res=>
    // {console.log(res)});
}
function delete1()
{
  let e = document.getElementById("s");
   e= e.options[e.selectedIndex].text;
  fetch(`https://localhost:44341/api/Role/${e}`,{method:'DELETE'});
}
function update(){
        var id=document.getElementById("s2").value;
        var role=document.getElementById("inp").value;
        var desc=document.getElementById("inp2").value;
  fetch(`https://localhost:44341/api/Role`,{
      method:'PUT',
      headers:{"Content-Type":"application/json"}, 
      body: JSON.stringify({id:id,name:role, description:desc})
  })
}
function addRole(){
  var id=document.getElementById("id1").value;
  var role=document.getElementById("name1").value
  var desc=document.getElementById("desc1").value;
  fetch(`https://localhost:44341/api/Role`,{
      method:'POST',
      headers:{"Content-Type":"application/json"}, 
      body: JSON.stringify({id:id,name:role, description:desc})
  })
}