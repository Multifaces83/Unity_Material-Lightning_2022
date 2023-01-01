# Unity_CC_Material_Lightning

## Objectif global du projet

Suite au changement de projet, nous allons partir des projets de base fournis par Unity Learn pour découvrir les matériaux et les lumières.
Les projets shaders (et matériaux) et lumière ont été associé et transférés en version 2021.3.15f1.

## Rappels de vocabulaire 

- Shader : script/code permettant de définir comment un modèle sera afficher à l'écran
- Matérial : élément créé à partir d'un shader pour être appliqué à un mesh. Comporte toutes les informations nécessaire pour que le shader soit calculé

## Assets disponibles

- Les deux répertoires CreatorCore viennent d'unity learn : ils sont simples mais géniaux pour des exercices d'explication ou des tests. Les deux ont des scènes finales qui peuvent servir d'exemples. Attention certains éléments doivent être réalisés en exercice donc vous n'aurez pas forcément tous les exemples possibles.
- Les  répertoires free furniture et simple garage sont des esemple de props pour habiller rapidement.
- SI vous voulez utiliser d'autres assets : pensez a faire de la place en suprimant soit le garage soit les fournitures. Gardez les projets unity pour le lundi de la rentrée 

## Eléments à réaliser

- Créer deux pièces simples avec de l'espace, une fenetre, une porte et quelques meubles simples (une pièce avec table et une autre de type garage au vu des assets)
- Créer les matériaux nécessaires pour la pièce. Avec au minimum : un matérial mat, un autre métallique et un autre de type verre
- Placer des lumières pour éclairer la pièce
- Mettre en place un bouton pour allumer les lumières (script et trigger)
- Mettre en place un systeme pour changer le matérial d'un objet (raycast, input de déclenchement et application d'un matérial différent)
- Mettre en place un systeme pour changer le modèle d'un objet (raycast, input, systeme de destroy/spawn de meuble)

