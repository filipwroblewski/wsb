<html>
	<body>
		<?php

			$text = $_GET["textToProcess"];
			$key = $_GET["key"];

			echo "<h3>Przetwarzany tekst:</h3>".$text."<br><h3>Klucz: ".$key."</h3><br>";

			$processedText = "";
			for ($i=0; $i < strlen($text) ; $i++) {
				$letter = $text[$i];
				if((ord($letter) >= 65 && ord($letter) <= 90)){
					if ((ord($letter) + $key) > 90) {
						$letter = chr(65 + (ord($letter) - 90 - 1) + $key);
					}elseif ((ord($letter) + $key) < 65) {
						$letter = chr(90 - (65 - ord($letter) - 1) + $key);
					}
					else{
						$letter = chr(ord($letter) + $key);
					}
				}elseif ((ord($letter) >= 97 && ord($letter) <= 122)) {
					if ((ord($letter) + $key) > 122) {
						$letter = chr(97 + (ord($letter) - 122 - 1) + $key);
					}elseif ((ord($letter) + $key) < 97) {
						$letter = chr(122 - (97 - ord($letter) - 1) + $key);
					}
					else{
						$letter = chr(ord($letter) + $key);
					}
				}
				$processedText = $processedText.$letter;
			}
			echo "<h3>Tekst po przetworzeniu:</h3>".$processedText;
		?>
	</body>
</html>

