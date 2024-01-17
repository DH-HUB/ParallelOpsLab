# Exercice 1
- Réaliser des opérations simples avec la programmation parallèle

## Steps
### Step 1 : First usage of Parallel.ForEach
- Ajoutez l'import pour System.Threading.Tasks à votre projet. 
- Dans la méthode main, créez une liste de nombre à procéder, par exemple, une liste de nombre de 1 à 10.
- Utilisez la méthode Parallel.ForEach pour afficher les nombres de la liste de manière concurrentielle.
- Ajoutez un Thread.Sleep(1000) à l'intérieur du ForEach.
- Démarrer votre programme et observez la sortie

### Step 2 : Adding a Stopwatch to check the time elapsed during operations
- Ajoutez un Stopwatch pour analyser le temps nécessaire pour réaliser l'opération, sans programmation parallèle, l'opération durerait minimum 10 secondes (vous pouvez tester d'ailleur avec un simple ForEach sur la liste)
```
var timer = new Stopwatch() // un import sera nécessaire
timer.Start();
// Opération ForEach Step 1
timer.Stop();
Console.WriteLine("{0} Elapsed time to process the list", timer.Elapsed.ToString());
```

### Step 3 : First usage of Parallel.For
- Réaliser les mêmes opérations que précédemment en utilisant Parallel.For
- Pour redémarrer le timer utilisez : 
```
timer.Reset();
```

### Step 4 : First usage of Parallel.Invoke
- Réaliser des tâches concurrentielles grâce à la méthode Parallel.Invoke
- La première Action doit process les nombres de 1 à 10 avec un Thread.Sleep(1000);
- La seconde Action doit process les nombres de 10 à 20 avec un Thread.Sleep(1500);
- Ajoutez la méthode Parallel.Invoke pour lancer en parallèle les deux actions créées précédemment.
- Ajoutez autour de tout ça les méthodes permettant de calculer et afficher la durée, comme pour l'étape 2
- Pensez à Reset le timer
- Démarrer à nouveau votre programme et observez la sortie.

### Step 5 : First usage of aggregate with Parallel.Invoke
- Calculer la somme des valeurs de 1 à 100 en utilisant Parallel.Invoke & Aggregate
- Affichez le résultat du calcul
- Réaliser la même opération en utilisant directement 
```
numbers.Sum();
```
- Ajouter le timer afin de comparer la durée pour calculer le résultat.
- Que remarquez-vous ? Avez-vous une idée de pourquoi ce résultat n'est pas aussi satisfaisant qu'on l'aurait souhaité ?

### Step 6 : Using Action & Parallel.Invoke to read two file calculate the number of words in it
- Vous avez deux fichiers, le but est de compter le nombre de mots qui sont dans ces fichiers.
- Utilisez Action & Parallel.Invoke pour réaliser les deux opérations simultanément.
- Le séparateur est " "
- Affichez également ligne par ligne le nombre de mot.