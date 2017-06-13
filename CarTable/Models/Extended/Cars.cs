using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarTable.Models
{
    public class Cars
    {
    }
    public class CarsMetadata //проверка обязательных данных
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Пожалуйста введите марку автомобиля")]
        public string Brand { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста введите модель автомобиля")]
        public string Model { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста введите номер автомобиля")]
        public string Number { get; set; }
    }
}