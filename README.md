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
- [⚙️ Installation et Configuration](#️-installation-et-configuration)
- [🚀 Déploiement](#-déploiement)
- [📁 Structure du Projet](#-structure-du-projet)
- [📈 Résultats et Statistiques](#-résultats-et-statistiques)
- [📄 Rapport de Stage](#-rapport-de-stage)
- [🤝 Contribution](#-contribution)
- [📄 Licence](#-licence)

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
| **Génération PDF** | iTextSharp, Rotativa | - |

### Architecture MVC
L'application suit strictement le pattern **Modèle-Vue-Contrôleur** :<img width="700" height="393" alt="image" src="https://github.com/user-attachments/assets/0bc3828a-339c-4602-9d96-6629a375aa3a" />


## 📊 Diagrammes UML

### Diagramme de Classes Global
<img width="985" height="853" alt="image" src="https://github.com/user-attachments/assets/53ea1f41-6fbc-499b-bc07-2ab714b2c80e" />

### Diagramme de Cas d'utilisation Global
<img width="833" height="689" alt="image" src="https://github.com/user-attachments/assets/d4280ec9-5ece-4c8b-88f8-5c5238d8fe3f" />


### Diagrammes de Cas d'Utilisation
- **Gestion des Produits** : CRUD complet avec contraintes de stock
- **Gestion des Clients** : Distinction personnes physiques/morales
- **Gestion des Factures** : Workflow complet de création à impression
- **Gestion des Fournisseurs** : Suivi des commandes et paiements

## 🖥️ Interfaces Utilisateur

### Tableau de Bord Principal
![Tableau de Bord](https://via.placeholder.com/800x400/4A90E2/FFFFFF?text=Dashboard+ERP)
*Interface centralisée avec indicateurs clés et graphiques de performance*

### Gestion des Factures
```html
Interface comportant :
• Liste paginée des factures avec filtres avancés
• Formulaire de création avec sélection dynamique des produits
• Calcul automatique des totaux (HT, TVA, TTC)
• Système d'impression intégré avec mise en page professionnelle
• Visualisation détaillée avec lignes de facture
