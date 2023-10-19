try {
  var btn = document.querySelector(".toggle");
  var btnst = true;
  btn.onclick = function () {
    if (btnst == true) {
      document.querySelector(".toggle span").classList.add("toggle");
      document.getElementById("sidebar").classList.add("sidebarshow");
      btnst = false;
    } else if (btnst == false) {
      document.querySelector(".toggle span").classList.remove("toggle");
      document.getElementById("sidebar").classList.remove("sidebarshow");
      btnst = true;
    }
  };
} catch (error) {
  console.error(error);
}

try {
  var input = document.querySelector("#phone");
  window.intlTelInput(input, {
    separateDialCode: true,
    excludeCountries: [""],
    preferredCountries: ["se", "fi", "dk", "no"],
  });
} catch (error) {
  console.error(error);
}

try {
  function addListener(input) {
    input.addEventListener("keyup", () => {
      const code = parseInt(input.value);
      if (code >= 0 && code <= 9) {
        const n = input.nextElementSibling;
        if (n) n.focus();
      } else {
        input.value = "";
      }

      const key = event.key; // const {key} = event; ES6+
      if (key === "Backspace" || key === "Delete") {
        const prev = input.previousElementSibling;
        if (prev) prev.focus();
      }
    });
  }
  const inputs = ["input1", "input2", "input3", "input4", "input5"];

  inputs.map((id) => {
    const input = document.getElementById(id);
    addListener(input);
  });
} catch (error) {
  console.error(error);
}
