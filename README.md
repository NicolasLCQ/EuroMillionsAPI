# EuroMillionsAPI :

API pour récupérer les résultats de l'euromillions.
Récupère les résultats au format csv sur le site de la fdj. 
Les intègre dans une base de donnée au format siplifié : date, jour, numéros et étoiles.
L'API permet de synchroniser la base de donnée et de get les données.

Ce code a été fait rapidement pour apprendre les bases du c# et ne comporte pas de tests.

# Technos :

C#
SQL database

# Prérequis :

1) Installer un serveur d'instance de base de donnée
    - MySqld a été utilisé lors du développement
2) Changer l'adresse de connection a la base de donnée dans le fichier de paramètre pour correspondre à votre database
3) Lancer les commandes .NET de miggration pour initialiser la base de donnée
4) Lancer l'API
5) requetter l'API sur /synchronize pour remplir la base. Synchronize renvoie tout l'historique des résultats.
6) requeter /getAll de manière général pour aller chercher les résultats de la base de donnée.
