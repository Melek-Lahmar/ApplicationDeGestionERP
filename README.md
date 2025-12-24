# Application de Gestion ERP - Stage Infosoft

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-purple?style=for-the-badge&logo=.net)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red?style=for-the-badge&logo=microsoft-sql-server)
![MVC](https://img.shields.io/badge/Architecture-MVC-blue?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

## 📋 Table des Matières
- [📖 Introduction](#-introduction)
- [✨ Fonctionnalités](#-fonctionnalités)
- [🏗️ Architecture Technique](#️-architecture-technique)
- [📊 Diagrammes UML](#-diagrammes-uml)
- [🖥️ Interfaces Utilisateur](#️-interfaces-utilisateur)
- [📁 Structure du Projet](#-structure-du-projet)
- [⚙️ Installation et Configuration](#️-installation-et-configuration)


## 📖 Introduction

**Application de Gestion ERP** est une solution web complète développée dans le cadre d'un stage professionnel . Cette application permet la gestion intégrée des ventes, des stocks, des clients, des fournisseurs et des factures pour les entreprises.


### Objectifs du Projet
- Automatiser la gestion commerciale d'une entreprise
- Fournir des outils de reporting et d'analyse des ventes
- Implémenter un système de gestion des stocks en temps réel
- Offrir une interface intuitive adaptée à différents profils utilisateurs

## ✨ Fonctionnalités

### 🔐 Gestion des Utilisateurs et Sécurité
- **Authentification et autorisation** basée sur les rôles (Admin/Utilisateur)
- **Gestion des profils** avec différents niveaux d'accès
- **Sécurisation des données** sensibles

### 📦 Module de Gestion des Produits
- CRUD complet des articles (Créer, Lire, Mettre à jour, Supprimer)
- **Gestion des stocks** avec suivi des quantités
- **Catégorisation** des produits
- Import/Export des données produits

### 👥 Module de Gestion des Clients
- Gestion des clients (personnes physiques et morales)
- **Historique des achats** par client
- **Statistiques** de fidélité et de chiffre d'affaires

### 🏭 Module de Gestion des Fournisseurs
- Suivi des relations avec les fournisseurs
- **Gestion des commandes** et des livraisons
- **Analyse des performances** fournisseurs

### 🧾 Module de Gestion des Factures
- **Création et édition** de factures détaillées
- **Gestion des lignes de facture** (ajout/suppression de produits)
- **Système d'impression** professionnel des factures
- Calcul automatique des montants (HT, TVA, TTC)

### 📊 Tableau de Bord et Reporting
- **Graphiques interactifs** avec Chart.js
- **Statistiques de ventes** par article et par client
- **Indicateurs de performance** clés (KPI)
- **Rapports exportables** en PDF

## 🏗️ Architecture Technique

### Stack Technologique
| Composant | Technologie | Version |
|-----------|-------------|---------|
| **Backend** | ASP.NET Core MVC | 8.0 |
| **Frontend** | HTML5, CSS3, JavaScript, Bootstrap | 5.3 |
| **Base de données** | Microsoft SQL Server | 2022 |
| **ORM** | Entity Framework Core | 8.0 |
| **Authentification** | ASP.NET Core Identity | 8.0 |
| **Graphiques** | Chart.js | 4.4 |

### Architecture MVC
L'application suit strictement le pattern **Modèle-Vue-Contrôleur** :<img width="700" height="393" alt="image" src="https://github.com/user-attachments/assets/0bc3828a-339c-4602-9d96-6629a375aa3a" />


## 📊 Diagrammes UML

### Diagramme de Classes Global
<img width="985" height="853" alt="image" src="https://github.com/user-attachments/assets/53ea1f41-6fbc-499b-bc07-2ab714b2c80e" />

### Diagramme de Cas d'utilisation Global
<img width="833" height="689" alt="image" src="https://github.com/user-attachments/assets/d4280ec9-5ece-4c8b-88f8-5c5238d8fe3f" />


## 📋 Diagrammes de Cas d'Utilisation

## 👥 Acteurs du Système

- **Utilisateur standard** : Opérations quotidiennes de gestion
- **Administrateur** : Supervision, validation et reporting
- **Système** : Processus automatisés et notifications
Cette documentation présente les diagrammes de cas d'utilisation du système de gestion, détaillant les interactions entre les acteurs (utilisateurs) et les fonctionnalités principales.

### 🛒 Gestion des Produits
**Description** : Système complet de création, lecture, mise à jour et suppression (CRUD) des produits avec gestion avancée des contraintes de stock et des catégories.

**Fonctionnalités principales** :
- Création et gestion du catalogue produits
- Contrôle des niveaux de stock (alertes, seuils minimum)
- Organisation par catégories et sous-catégories
- Gestion des prix et promotions
- Suivi des mouvements d'inventaire
<img width="966" height="665" alt="image" src="https://github.com/user-attachments/assets/7cf2df7a-15db-4e10-9671-be851ea24a1d" />


### 👥 Gestion des Clients
**Description** : Gestion différenciée des clients selon leur profil (personnes physiques vs personnes morales) avec historique des interactions.

**Fonctionnalités principales** :
- Enregistrement des clients avec typologie distincte
- Profils complets (coordonnées, historique d'achats)
- Segmentation clientèle
- Suivi des relations commerciales
<img width="945" height="583" alt="image" src="https://github.com/user-attachments/assets/0ff5860e-6903-48dd-856e-24db476d8a65" />


### 🏷️ Gestion des Catégories
**Description** : Organisation hiérarchique des produits par catégories et sous-catégories pour une navigation et gestion optimisées.

**Fonctionnalités principales** :
- Création d'arborescences catégorielles
- Attribution multi-niveaux
- Gestion des propriétés par catégorie
- Organisation du catalogue produit
<img width="872" height="502" alt="image" src="https://github.com/user-attachments/assets/dd51ab40-9364-4fcc-a311-4f12859539f2" />

### 📄 Gestion des Factures - Interface Utilisateur
**Description** : Workflow complet de traitement des factures depuis la création jusqu'à l'impression pour les utilisateurs standards.

**Fonctionnalités principales** :
- Génération de factures
- Ajout de lignes de produits
- Calcul automatique des taxes et totaux
- Impression et export des documents
<img width="894" height="400" alt="image" src="https://github.com/user-attachments/assets/5f0a3e76-f8e1-468d-b035-6a2c22ef3e0c" />


### 📊 Gestion des Factures - Interface Administrateur
**Description** : Fonctionnalités étendues de gestion des factures réservées aux administrateurs du système.

**Fonctionnalités principales** :
- Validation et approbation des factures
- Gestion des remises exceptionnelles
- Suivi du cycle de vie des factures
- Reporting et statistiques financières
- Archivage et conservation légale
<img width="988" height="564" alt="image" src="https://github.com/user-attachments/assets/f31cf702-5079-4709-99f2-36f479b17f2e" />


### 📦 Gestion des Fournisseurs
**Description** : Suivi intégral des relations avec les fournisseurs, des commandes aux paiements.

**Fonctionnalités principales** :
- Gestion du référentiel fournisseurs
- Suivi des commandes d'approvisionnement
- Traçabilité des livraisons
- Gestion des paiements et règlements
- Évaluation des performances fournisseurs
<img width="922" height="561" alt="image" src="https://github.com/user-attachments/assets/b932d6ce-8370-4aab-881c-07791a279d1a" />





## 🖥️ Interfaces Utilisateur

### 📊 Tableau de Bord
<img width="1915" height="833" alt="image" src="https://github.com/user-attachments/assets/db827b51-836b-4c56-9825-ac47a5a3abd1" />


---

## 👤 FONCTIONS UTILISATEUR

### 📄 Gestion des Factures
**Création et suivi des factures clients**
<img width="945" height="448" alt="image" src="https://github.com/user-attachments/assets/4e7921fa-9a5e-41f7-a446-91d40aed42ed" />
<img width="945" height="431" alt="image" src="https://github.com/user-attachments/assets/b2227703-ba8b-48f9-af16-7203e471ce98" />
<img width="882" height="593" alt="image" src="https://github.com/user-attachments/assets/9915e88f-d137-467c-b4f6-995b20a579a1" />
<img width="893" height="589" alt="image" src="https://github.com/user-attachments/assets/ea9b2627-d768-4929-9297-864bdad6bdf5" />

### 🛒 Gestion des Produits
**Catalogue et gestion des stocks**
<img width="868" height="466" alt="image" src="https://github.com/user-attachments/assets/b6445cec-a220-47a5-b41a-0ade29137866" />
<img width="834" height="469" alt="image" src="https://github.com/user-attachments/assets/cc3ffa7c-eb3e-4f95-91e4-a1d995822962" />
<img width="770" height="606" alt="image" src="https://github.com/user-attachments/assets/f32eaf97-30bb-424f-833c-f086173f64c0" />
<img width="813" height="439" alt="image" src="https://github.com/user-attachments/assets/4da2652c-303d-4741-b51c-8525dd1ed73a" />
<img width="899" height="499" alt="image" src="https://github.com/user-attachments/assets/9053f494-2aa3-406c-a0f6-37fb32502993" />

### 👥 Gestion des Clients
**Annuaire et historique clients**
<img width="898" height="421" alt="image" src="https://github.com/user-attachments/assets/f8a53268-d6e8-497d-bed6-d25cb7609b28" />
<img width="935" height="374" alt="image" src="https://github.com/user-attachments/assets/9624d7c5-92b7-48e1-8e74-6271f16e8ae1" />
<img width="915" height="430" alt="image" src="https://github.com/user-attachments/assets/22a33e9b-a32e-42ba-aa15-d17575e50890" />
<img width="997" height="290" alt="image" src="https://github.com/user-attachments/assets/641d537b-26fb-454a-bc64-544477125dc2" />
<img width="912" height="328" alt="image" src="https://github.com/user-attachments/assets/d3aba453-1fc2-4d5b-a4ec-cce4cb3d2716" />

### 🏷️ Gestion des Catégories
**Organisation des produits par catégories**
<img width="945" height="445" alt="image" src="https://github.com/user-attachments/assets/08782f9e-b51d-4037-a5ec-ce321b5d83be" />
<img width="945" height="327" alt="image" src="https://github.com/user-attachments/assets/c6bd3739-84d7-41de-9b3e-6a78458800b4" />
<img width="945" height="274" alt="image" src="https://github.com/user-attachments/assets/b340b588-f70f-4d60-a6ce-187471d38b33" />
<img width="945" height="666" alt="image" src="https://github.com/user-attachments/assets/ff5b7526-03bc-4901-9867-1bd2e602fdb1" />



---

## 🔧 FONCTIONS ADMINISTRATEUR

### 📦 Gestion des Utilisateur
<img width="945" height="343" alt="image" src="https://github.com/user-attachments/assets/593cc14c-4af8-43c5-93df-80e49ca1154c" />
<img width="980" height="304" alt="image" src="https://github.com/user-attachments/assets/d55ad5f6-bbfb-4b7b-9e00-38efc0e821eb" />
<img width="932" height="287" alt="image" src="https://github.com/user-attachments/assets/daad64d2-15a3-4662-a130-64200b3db053" />
<img width="945" height="243" alt="image" src="https://github.com/user-attachments/assets/f2eda172-49fc-49cc-a24d-8263fb362f0d" />


### 📈 Reporting & Analytics
**Analyse complète et tableaux de bord avancés**
<img width="945" height="459" alt="image" src="https://github.com/user-attachments/assets/7e94d22f-0280-4ebe-939a-2324421d0eb3" />
<img width="957" height="474" alt="image" src="https://github.com/user-attachments/assets/8e1317f1-b8b3-4b85-9b20-80c8599df862" />


---


### 📁 Structure des Dossiers

# Structure du projet ApplicationDeGestionERP

ApplicationDeGestionERP/
- FICHIERS RACINE
  - ApplicationDeGestionERP.csproj        # Configuration du projet .NET
  - ApplicationDeGestionERP.sln           # Solution Visual Studio
  - Program.cs                             # Point d'entrée de l'application
  - appsettings.json                       # Configuration générale
  - appsettings.Development.json           # Configuration développement
  - README.md                              # Documentation du projet

- AREAS (Modules fonctionnels)
  - Employes/                              # Module gestion des employés
    - Controllers/
    - Models/
    - Views/
  - Identity/                              # Module authentification
    - Pages/
      - Account/                           # Pages de connexion, inscription
      - Manage/                            # Gestion du compte utilisateur

- CONTROLLERS
  - HomeController.cs                       # Page d'accueil
  - DashBoardController.cs                  # Tableau de bord
  - G_ArticleController.cs                  # Gestion articles
  - G_CategorieController.cs                # Gestion catégories
  - G_ClientController.cs                   # Gestion clients
  - G_FactureController.cs                  # Gestion factures
  - G_FournisseurController.cs              # Gestion fournisseurs
  - G_UtilisateursController.cs             # Gestion utilisateurs

- MODELS
  - G_Article.cs                            # Modèle Article
  - G_Categorie.cs                          # Modèle Catégorie
  - G_Client.cs                              # Modèle Client
  - G_Facture.cs                             # Modèle Facture
  - G_Fournisseur.cs                         # Modèle Fournisseur
  - G_LigneFacture.cs                        # Modèle Ligne de facture
  - G_Utilisateurs.cs                        # Modèle Utilisateur
  - ErrorViewModel.cs                        # Modèle d'erreur

- DATABASE
  - Data/
    - ApplicationDbContextes.cs            # Contexte de base de données
  - Migrations/                             # Migrations Entity Framework
    - *.cs                                 # Fichiers de migration

- VIEWS
  - Home/                                   # Pages publiques
  - DashBoard/                              # Interface tableau de bord
  - G_Article/                              # Interface articles
  - G_Categorie/                            # Interface catégories
  - G_Client/                               # Interface clients
  - G_Facture/                              # Interface factures
  - G_Fournisseur/                          # Interface fournisseurs
  - G_Utilisateurs/                         # Interface utilisateurs
  - Shared/                                 # Templates partagés
    - _Layout.cshtml                        # Layout principal
    - _LayoutAdmin.cshtml                   # Layout administrateur
    - _LoginPartial.cshtml                  # Partiel connexion

- WWWROOT (Assets statiques)
  - css/                                    # Feuilles de style personnalisées
  - js/                                     # Scripts JavaScript
  - images/                                 # Images et logos
  - assetsDash/                             # Assets du tableau de bord
  - assetsI/                                # Assets d'interface
  - lib/                                    # Bibliothèques tierces
    - bootstrap/                            # Framework CSS
    - jquery/                               # Bibliothèque JavaScript
    - jquery-validation/                    # Validation de formulaires
    - jquery-validation-unobtrusive/       # Validation non intrusive

- HELPERS
  - NumberToWordsConverter.cs               # Utilitaire de conversion nombres en mots

- PROPERTIES
  - launchSettings.json                      # Paramètres de lancement

- BIN/                                      # Fichiers compilés
- OBJ/                                      # Fichiers temporaires de compilation


---

## ⚙️ Installation et Configuration

### 📥 1. Téléchargement du Projet

Vous pouvez choisir l'une des deux méthodes ci-dessous :

🔹 Méthode 1 : Cloner avec Git (Recommandé)

git clone https://github.com/Melek-Lahmar/ApplicationDeGestionERP.git

cd ApplicationDeGestionERP

🔹 Méthode 2 : Téléchargement ZIP

Accédez à : https://github.com/Melek-Lahmar/ApplicationDeGestionERP

Cliquez sur "Code" → "Download ZIP"

Extrayez l’archive dans votre dossier de travail

Ouvrez un terminal dans le dossier extrait
