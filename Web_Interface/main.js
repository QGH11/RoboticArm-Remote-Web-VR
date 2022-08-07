// slider
var slider1 = document.getElementById("myRange1");
var output1 = document.getElementById("demo1");
var slider2 = document.getElementById("myRange2");
var output2 = document.getElementById("demo2");
var slider3 = document.getElementById("myRange3");
var output3 = document.getElementById("demo3");
var slider4 = document.getElementById("myRange4");
var output4 = document.getElementById("demo4");
var slider5 = document.getElementById("myRange5");
var output5 = document.getElementById("demo5");
var slider6 = document.getElementById("myRange6");
var output6 = document.getElementById("demo6");

output1.innerHTML = slider1.value; // Display the default slider value
output2.innerHTML = slider2.value;
output3.innerHTML = slider3.value;
output4.innerHTML = slider4.value;
output5.innerHTML = slider5.value;
output6.innerHTML = slider6.value;

slider1.oninput = function() {
  output1.innerHTML = this.value;
  console.log(slider1.value)
}
slider2.oninput = function() {
  output2.innerHTML = this.value;
}
slider3.oninput = function() {
  output3.innerHTML = this.value;
}
slider4.oninput = function() {
  output4.innerHTML = this.value;
}
slider5.oninput = function() {
  output5.innerHTML = this.value;
}
slider6.oninput = function() {
  output6.innerHTML = this.value;
}

// send data when slider value changes
document.querySelectorAll('.slider').forEach(item => {
  // Create an event listener on the button element:
  item.addEventListener('input', event=> {
      // Get the reciever endpoint from Python using fetch:
      motors = {"degree":
                  [ slider1.value ,
                    slider2.value ,
                    slider3.value ,
                    slider4.value ,
                    slider5.value ,
                    slider6.value ]
                };
      fetch("http://127.0.0.1:5000/receiver", 
          {
              method: 'POST',
              headers: {
                  'Content-type': 'application/json',
                  'Accept': 'application/json'
              },
          // Strigify the payload into JSON:
          body:JSON.stringify(motors)}).then(res=>{
                  if(res.ok){
                      return res.json()
                  }else{
                      alert("something is wrong")
                  }
              }).then(jsonResponse=>{
                  
                  // Log the response data in the console
                  console.log(jsonResponse)
              } 
              ).catch((err) => console.error(err)); 
        })
})
