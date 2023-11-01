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

try {
    function controlFromInput(fromSlider, fromInput, toInput, controlSlider) {
        const [from, to] = getParsed(fromInput, toInput);
        fillSlider(fromInput, toInput, "#111111", "#111111", controlSlider);
        if (from > to) {
            fromSlider.value = to;
            fromInput.value = to;
        } else {
            fromSlider.value = from;
        }
    }

    function controlToInput(toSlider, fromInput, toInput, controlSlider) {
        const [from, to] = getParsed(fromInput, toInput);
        fillSlider(fromInput, toInput, "#DBE3F5", "#111111", controlSlider);
        setToggleAccessible(toInput);
        if (from <= to) {
            toSlider.value = to;
            toInput.value = to;
        } else {
            toInput.value = from;
        }
    }

    function controlFromSlider(fromSlider, toSlider, fromInput) {
        const [from, to] = getParsed(fromSlider, toSlider);
        fillSlider(fromSlider, toSlider, "#DBE3F5", "#111111", toSlider);
        if (from > to) {
            fromSlider.value = to;
            fromInput.value = to;
        } else {
            fromInput.value = from;
        }
    }

    function controlToSlider(fromSlider, toSlider, toInput) {
        const [from, to] = getParsed(fromSlider, toSlider);
        fillSlider(fromSlider, toSlider, "#DBE3F5", "#111111", toSlider);
        setToggleAccessible(toSlider);
        if (from <= to) {
            toSlider.value = to;
            toInput.value = to;
        } else {
            toInput.value = from;
            toSlider.value = from;
        }
    }

    function getParsed(currentFrom, currentTo) {
        const from = parseInt(currentFrom.value, 10);
        const to = parseInt(currentTo.value, 10);
        return [from, to];
    }

    function fillSlider(from, to, sliderColor, rangeColor, controlSlider) {
        const rangeDistance = to.max - to.min;
        const fromPosition = from.value - to.min;
        const toPosition = to.value - to.min;
        controlSlider.style.background = `linear-gradient(
    to right,
    ${sliderColor} 0%,
    ${sliderColor} ${(fromPosition / rangeDistance) * 100}%,
    ${rangeColor} ${(fromPosition / rangeDistance) * 100}%,
    ${rangeColor} ${(toPosition / rangeDistance) * 100}%, 
    ${sliderColor} ${(toPosition / rangeDistance) * 100}%, 
    ${sliderColor} 100%)`;
    }

    function setToggleAccessible(currentTarget) {
        const toSlider = document.querySelector("#toSlider");
        if (Number(currentTarget.value) <= 0) {
            toSlider.style.zIndex = 2;
        } else {
            toSlider.style.zIndex = 0;
        }
    }

    const fromSlider = document.querySelector("#fromSlider");
    const toSlider = document.querySelector("#toSlider");
    const fromInput = document.querySelector("#fromInput");
    const toInput = document.querySelector("#toInput");
    fillSlider(fromSlider, toSlider, "#DBE3F5", "#111111", toSlider);
    setToggleAccessible(toSlider);

    fromSlider.oninput = () => controlFromSlider(fromSlider, toSlider, fromInput);
    toSlider.oninput = () => controlToSlider(fromSlider, toSlider, toInput);
    fromInput.oninput = () =>
        controlFromInput(fromSlider, fromInput, toInput, toSlider);
    toInput.oninput = () =>
        controlToInput(toSlider, fromInput, toInput, toSlider);
} catch (error) {
    console.error(error);
}

try {
    const labels = document.querySelectorAll(".containerSizes");

    labels.forEach((label) => {
        const p = label.querySelector("span");
        label.style.width = `${p.clientWidth}px`;
        label.style.height = `${p.clientHeight}px`;
    });
} catch (error) {
    console.error(error);
}
