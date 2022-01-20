<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Szyfr Cezara</title>
</head>
<body>
	<form action="cezar.php" method="get">
		<label for="textToProcess">Tekst do przetworzenia: </label><br>
		<textarea id="textToProcess" name="textToProcess" rows="10" cols="50">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam fringilla sem et orci condimentum volutpat. Cras massa arcu, gravida sed congue pharetra, vulputate eget nulla. Quisque vitae dui pretium, porttitor elit quis, congue metus. Donec in ex sed arcu maximus varius. Suspendisse quis enim justo. Sed eu arcu sed orci pulvinar sagittis. Morbi vel convallis ipsum, ac ultrices sapien. Vivamus sed aliquam felis. Aliquam iaculis nisi sem, et facilisis nunc varius non. Vestibulum commodo neque tellus, semper porttitor dolor suscipit eget. Cras ante eros, convallis in vestibulum et, tempus in massa. Cras at ligula est. Donec eu orci nec nulla pulvinar vestibulum. Pellentesque massa nisl, tempor vel congue gravida, tempus ut orci.</textarea><br><br>

		<label for="key">Przesunięcie (klucz)</label><br>
		<input id="key" name="key" type="number" name="key" value="5" min="-25" max="25"><br>

		<button type="submit">Prześlij</button>
	</form>
</body>
</html>