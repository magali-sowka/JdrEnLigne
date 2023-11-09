let formOneshot = document.getElementById("form-oneshot");
let formCampagne = Array.from(document.getElementsByClassName("form-campagne"));
formOneshot.hidden = false;
formCampagne.forEach(elt => elt.hidden = true);

// Affiche la partie du formulaire correspondant au format de partie sélectionné et efface les données de la partie cachée

const radioBtn = document.querySelectorAll("input[type='radio']");

radioBtn.forEach(btn => btn.addEventListener("change", () => {
	if (radioBtn[0].checked) {
		formOneshot.hidden = false;
		formCampagne.forEach(elt => elt.hidden = true);
	}
	else {
		formOneshot.hidden = true;
		formCampagne.forEach(elt => elt.hidden = false);
	}
}));

//let freqInput = document.getElementById("freq");
//let freqValue = freqInput.value.trim();
//let freqError = document.getElementById("freqError");

//let dureeInput = document.getElementById("duree");
//let dureeValue = dureeInput.value.trim();
//let dureeError = document.getElementById("dureeError");

//let nbScesValue = parseInt(document.getElementById("nbSces").value);
//let nbScesError = document.getElementById("nbScesError");

//let checkboxes = document.querySelectorAll('input[name="selectedGenres"]:checked');
//let checkError = document.getElementById("checkError");

//document.getElementById("form").addEventListener("submit", function (event) {
	
//	let error = false;

//	if (checkboxes.length === 0) {
//		checkError.innerHTML = "Veuillez sélectionner au moins un thème";
//		error = true;
//	}

//	if (radioBtn[1].checked) {

//		if (freqValue === "") {
//			freqError.innerHTML = "Veuillez entrer une fréquence des séances";
//			error = true;
//		}
//		if (dureeValue === "" ) {
//			dureeError.innerHTML = "Veuillez entrer une durée estimée de la campagne";
//			error = true;
//		}
//	}

//	if (radioBtn[0].checked) {
//		if (isNaN(nbScesValue) || !Number.isInteger(nbScesValue) || nbScesValue <= 0) {
//			nbScesError.innerHTML = "Veuillez entrez un nombre de séances supérieur ou égale à 1";
//			error = true;
//		}
//	}

//	if (error) {
//		event.preventDefault();
//	}
//});


