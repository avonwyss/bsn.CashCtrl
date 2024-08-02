using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;
using Xunit.Abstractions;

namespace bsn.CashCtrl {
	public sealed class UpdateFrench: TestClassBase {
		public UpdateFrench(ITestOutputHelper output): base(output) { }

		[Fact(Skip = "Modifies the content of the account")]
		public void UpdateAccounts() {
			var accountLabels = new Dictionary<int, string>() {
					{ 1, "Actifs" },
					{ 10, "Actifs circulants" },
					{ 100, "Liquidités" },
					{ 1000, "Caisse" },
					{ 1010, "Post" },
					{ 1020, "Banque" },
					{ 1021, "Postfinance" },
					{ 1090, "Compte de virement" },
					{ 106, "Actifs à court terme cotés en bourse" },
					{ 1060, "Titres" },
					{ 110, "Créances résultant de livraisons et prestations" },
					{ 1100, "Débiteurs" },
					{ 1101, "Créances sur carte de crédit" },
					{ 1109, "Ducroire" },
					{ 114, "Autres créances à court terme" },
					{ 1140, "Avances et prêts accordés" },
					{ 1170, "Impôt préalable" },
					{ 1172, "Réconciliation de l'impot préalable lors de changement de méthode" },
					{ 1174, "Correction de l'impôt préalable" },
					{ 1176, "Impôt anticipé" },
					{ 1180, "Compte courant assurances sociales" },
					{ 1190, "Autres créances à court terme" },
					{ 120, "Stocks" },
					{ 1200, "Marchandises" },
					{ 1210, "Matériel" },
					{ 1260, "Produits finis" },
					{ 1270, "Produits semi-finis" },
					{ 1280, "Prestations de services non facturées" },
					{ 130, "Comptes de régularisation actifs" },
					{ 1300, "Charges payées d'avance" },
					{ 1301, "Produits à recevoir" },
					{ 14, "Actifs immobilisés" },
					{ 140, "Immobilisations financières" },
					{ 1400, "Titres à long terme" },
					{ 1430, "Autres immobiliations financières" },
					{ 1440, "Prêts accordés" },
					{ 1441, "Hypothéques" },
					{ 148, "Participations" },
					{ 1480, "Participations" },
					{ 150, "Immobilisations corporelles mobiles" },
					{ 1500, "Machines (appareils)" },
					{ 1509, "Cumul d'amortissements machines (appareils)" },
					{ 1510, "Mobilier et installations" },
					{ 1519, "Cumul d'amortissements mobilier et installations" },
					{ 1520, "Machines de bureau, informatique, communication" },
					{ 1529, "Cumul d'amortissements machines de bureau (inclus inform.)" },
					{ 1530, "Véhicules" },
					{ 1539, "Cumul d'amortissements véhicules" },
					{ 1540, "Outillage (appareils)" },
					{ 1549, "Cumul d'amortissements outillage (appareils)" },
					{ 1550, "Livres" },
					{ 1559, "Cumul d'amortissements installations de stockage" },
					{ 160, "Immobilisations corporelles immeubles" },
					{ 1600, "Biens fonciers d'exploitation" },
					{ 1609, "Cumul d'amortiss. immeubles (biens fonciers d'exploitation)" },
					{ 1660, "Immeubles (biens fonciers hors exploitation)" },
					{ 1669, "Cumul d'amortiss. immeubles (biens fonciers hors exploitation)" },
					{ 170, "Immobilisations incorporelles" },
					{ 1700, "Brevets, licences, droits" },
					{ 1709, "Cumul d'amortissements brevets" },
					{ 1720, "Licences" },
					{ 1729, "Cumul d'amortissements licences" },
					{ 1770, "Goodwill" },
					{ 1779, "Cumul d'amortissements goodwill" },
					{ 180, "Capital social non libéré" },
					{ 1850, "Capital-actions non libéré" },
					{ 2, "Passifs" },
					{ 20, "Dettes à court terme" },
					{ 200, "Dettes à court terme résultant d'achats et de prestations de services" },
					{ 2000, "Créanciers" },
					{ 2030, "Acomptes de clients" },
					{ 210, "Dettes à court terme rémunérées" },
					{ 2100, "Dettes bancaires à court terme" },
					{ 2101, "Postfinance (dette en compte-courant)" },
					{ 2108, "Hypothèques" },
					{ 2120, "Engagements de financement par leasing" },
					{ 2140, "Autres dettes portant intérêt" },
					{ 220, "Autres dettes à court terme" },
					{ 2200, "TVA due" },
					{ 2202, "Compensation TVA due selon méthode de décompte" },
					{ 2206, "Impôt anticipé dû" },
					{ 2208, "Impôts directs" },
					{ 2210, "Autres dettes à court terme" },
					{ 2261, "Dividendes décidées" },
					{ 2262, "Tantièmes" },
					{ 2270, "Créanciers assurances sociales" },
					{ 2279, "Compte courant Impôt à la source" },
					{ 230, "Comptes de régularisation passifs et provisions à court terme" },
					{ 2300, "Comptes de régularisation passifs (passifs transitoires)" },
					{ 2301, "Produits encaissés d'avance" },
					{ 2330, "Provisions à court terme" },
					{ 24, "Dettes à long terme" },
					{ 240, "Dettes à long terme rémunérées" },
					{ 2400, "Dettes bancaires à long terme" },
					{ 2420, "Engagements de financement par leasing" },
					{ 2430, "Emprunts obligataires" },
					{ 2450, "Emprunts à long terme" },
					{ 2451, "Hypothèques" },
					{ 250, "Autres dettes à long terme" },
					{ 2500, "Autres dettes à long terme sans intérêt" },
					{ 260, "Provisions à long terme et provisions légales" },
					{ 2600, "Provisions à long terme" },
					{ 28, "Capital propre" },
					{ 280, "Capital de base" },
					{ 2800, "Capital social" },
					{ 2820, "Compte associé privé" },
					{ 2850, "Compte entrepreneur privé" },
					{ 2891, "Bénéfice ou perte de l'exercice" },
					{ 290, "Réserves" },
					{ 2900, "Agio à la fondation ou lors d'augmentations de capital" },
					{ 2930, "Réserve propre capital" },
					{ 2940, "Réserve d'évaluation" },
					{ 2950, "Réserve légale issue du bénéfice" },
					{ 2960, "Réserve libre" },
					{ 3, "Charges" },
					{ 30, "Produit d'exploitation" },
					{ 3000, "Ventes de produits fabriqués" },
					{ 3200, "Ventes de marchandises" },
					{ 3400, "Ventes de prestations de services" },
					{ 3410, "Produits de transports" },
					{ 3420, "Produits d'honoraires" },
					{ 3600, "Autres produits livraisons, services" },
					{ 3700, "Prestations à soi-même" },
					{ 3710, "Consommation propre" },
					{ 3800, "Escomptes sur ventes" },
					{ 3805, "Pertes sur débiteurs" },
					{ 3900, "Variation des stocks de produits semi-finis" },
					{ 3901, "Variation des stocks de produits finis" },
					{ 3920, "Variation de l'état des travaux en cours non facturés" },
					{ 3940, "Variation de la valeur des prestations non facturées" },
					{ 4, "Produits" },
					{ 40, "Charges livraisons, services" },
					{ 4000, "Charges de matériel de production" },
					{ 4200, "Charges de marchandises" },
					{ 4400, "Charges pour prestations" },
					{ 4500, "Charges d'énergie pour la fabrication" },
					{ 4660, "Charges de provision pour travaux de garantie" },
					{ 4900, "Escomptes sur achats" },
					{ 5810, "Formation continue/perfectionnement" },
					{ 5820, "Indemnités de frais" },
					{ 5900, "Prestations de tiers" },
					{ 5, "Bilan" },
					{ 50, "Charges de personnel" },
					{ 5000, "Salaires" },
					{ 5700, "Charges sociales" },
					{ 5800, "Autres charges de personnel" },
					{ 6, "Autres charges d'exploitation, amortissements et corrections de" },
					{ 60, "Autres charges d'exploitation" },
					{ 6000, "Charges de locaux (loyers)" },
					{ 6100, "Entretien, réparations et remplacement des installations (ERR)" },
					{ 6105, "Leasing équipement de production" },
					{ 6200, "Charges de véhicules et transports" },
					{ 6260, "Véhicules en leasing et location" },
					{ 6300, "Charges d'assurances (inclus droits, taxes, autorisations)" },
					{ 6400, "Charges d'énergie et d'évacuation des déchets" },
					{ 6500, "Charges d'administration" },
					{ 6513, "Charges de port" },
					{ 6570, "Charges d'informatique" },
					{ 6600, "Publicité" },
					{ 6700, "Autres charges d'exploitation" },
					{ 6800, "Amortissements" },
					{ 6801, "Sorties d'immobilisations" },
					{ 6900, "Charges financières" },
					{ 6950, "Produits financiers" },
					{ 6960, "Différences de change" },
					{ 6961, "Différences d'arrondis" },
					{ 7, "Résultat des activités annexes d'exploitation" },
					{ 70, "Résultat des activités annexes d'exploitation" },
					{ 7000, "Produits accessoires" },
					{ 7010, "Charges accessoires" },
					{ 7500, "Produits des immeubles" },
					{ 7510, "Charges des immeubles" },
					{ 7900, "Revenu immobilisations corporelles mobiles" },
					{ 7910, "Revenu immobilisations incorporelles" },
					{ 8, "Charges et produits hors exploitation, extraordinaires, uniques ou" },
					{ 80, "Résultat hors exploitation" },
					{ 8000, "Charges hors exploitation" },
					{ 8010, "Charges des immeubles (biens-fonciers hors exploitation)" },
					{ 8100, "Produits hors exploitation" },
					{ 8110, "Produits des immeubles (biens-fonciers hors exploitation)" },
					{ 8500, "Charges extraordinaires" },
					{ 8510, "Produits extraordinaires" },
					{ 8900, "Impôts directs" },
					{ 9, "Clôture" },
					{ 90, "Ouverture / clôture" },
					{ 9100, "Bilan d'ouverture" },
					{ 9200, "Bénéfice ou perte de l'exercice" }
			};
			var categories = this.Client.AccountCategoryList();
			foreach (var category in categories.Where(c => !c.IsSystem).OrderBy(c => c.Number.PadLeft(4, '0'))) {
				if (!accountLabels.TryGetValue(int.Parse(category.Number), out var label)) {
					this.Output.WriteLine($"{{ {category.Number}, \"{category.Name}\" }}");
				} else {
					if (category.Name.TryGetLanguage("FR", out var existingLabel)) {
						this.Output.WriteLine($"Label exists for {category.Number}: {category.Name.ToString("FR")} (new label: {label})");
					} else {
						this.Output.WriteLine($"{category.Number}: {category.Name.ToString("DE")} => {label}");
					}
					category.Name = category.Name.Multilanguage().Set("FR", label);
					this.Client.AccountCategoryUpdate(category);
				}
			}
			var accounts = this.Client.AccountList();
			foreach (var account in accounts.OrderBy(a => a.Number)) {
				if (!accountLabels.TryGetValue(int.Parse(account.Number), out var label)) {
					this.Output.WriteLine($"{{ {account.Number}, \"{account.Name}\" }}");
				} else {
					if (account.Name.TryGetLanguage("FR", out var existingLabel)) {
						this.Output.WriteLine($"Label exists for {account.Number}: {account.Name.ToString("FR")} (new label: {label})");
					} else {
						this.Output.WriteLine($"{account.Number}: {account.Name.ToString("DE")} => {label}");
					}
					var updatedAccount = this.Client.AccountRead(account);
					updatedAccount.Name = account.Name.Multilanguage().Set("FR", label);
					this.Client.AccountUpdate(updatedAccount);
				}
			}
		}
	}
}
