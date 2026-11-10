using Guignolee.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Guignolee.ViewModels
{
    public class DonViewModel:ValidableViewModel
    {
        private readonly Don _don;

        public DonViewModel(Don don)
        {
            _don = don;
            
            _errors.Add(nameof(Donateur), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Contenu), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Quantite), new ObservableCollection<ValidationResult>());
            
        }

        public int Id => _don.Id;






        public string Donateur
        {
            get { return _don.Donateur; }
            set
            {
                if (_don.Donateur != value)
                {
                    _don.Donateur = value;

                }
                else
                {
                    Validate(value);
                }
            }
        }
        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 à 50 caractères.")]
        [RegularExpression(@"^[\p{L} '’-]+$", ErrorMessage = "Lettres, espaces, - et ' seulement.")]

        public string Contenu
        {
            get { return _don.Contenu; }
            set
            {
                if (_don.Contenu != value )
                {
                    _don.Contenu = value;
                }
                else
                {
                    Validate(value);
                }
            }
        }
        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 à 50 caractères.")]
        [RegularExpression(@"^[\p{L} '’-]+$", ErrorMessage = "Lettres, espaces, - et ' seulement.")]

        public int Quantite
        {
            get { return _don.Quantite; }
            set
            {
                if (Quantite != value)
                {
                    _don.Quantite = value;

                }
                else
                {
                    Validate(value);
                }
            }
        }
        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "3 à 100 caractères.")]

        public bool EstPerissable
        {
            get { return _don.EstPerissable; }
            set
            {
                if (_don.EstPerissable != value)
                {
                    _don.EstPerissable = value;
                }
                
                
            }
        }

        public bool EstRemis
        {
            get { return _don.EstRemis; }
            set
            {
                if (_don.EstRemis != value)
                {
                    _don.EstRemis = value;
                }

            }
        }
        

        public DateTime DateReception => _don.DateReception;

        public string Details
        {
            get
            {
                return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy}";
            }
        }
    }
}
