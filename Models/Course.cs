using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace ws_courses.Models {
    public class Course {
        public int Id { get; set; }
        [Required(ErrorMessage = "Título do curso deve ser informado!", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "O Título do curso deve ter no máximo 100 caracteres!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "A URL de acesso ao curso deve ser informada!", AllowEmptyStrings = false)]
        [Url(ErrorMessage = "A URL do curso deve respeitar os padrões web!")]
        public string URL { get; set; }
        [Required(ErrorMessage = "O canal de acesso ao material do curso deve ser informado!", AllowEmptyStrings = false)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Channel Channel { get; set; }
        [Required(ErrorMessage = "A data de publicação do curso deve ser informada!", AllowEmptyStrings = false)]
        public DateTime PublicationDate { get; set; }
        [Required(ErrorMessage = "A carga horária do curso deve ser informada!", AllowEmptyStrings = false)]
        [Range(1, Int32.MaxValue, ErrorMessage = "A carga horária deve ter no minímo 1 hora!")]
        public int WorkSchedule { get; set; }
    }
}