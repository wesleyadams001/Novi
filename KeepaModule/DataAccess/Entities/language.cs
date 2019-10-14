namespace KeepaModule.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.languages")]
    public partial class language
    {
        public language(ulong? product_id, string language_name, string language_type, string audio_format, long? time_stamp)
        {
            this.product_id = product_id ?? throw new ArgumentNullException(nameof(product_id));
            this.language_name = language_name ?? throw new ArgumentNullException(nameof(language_name));
            this.language_type = language_type ?? throw new ArgumentNullException(nameof(language_type));
            this.audio_format = audio_format ?? throw new ArgumentNullException(nameof(audio_format));
            this.time_stamp = time_stamp ?? throw new ArgumentNullException(nameof(time_stamp));
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int languages_id { get; set; }

        public ulong? product_id { get; set; }

        public string language_name { get; set; }

        public string language_type { get; set; }

        public string audio_format { get; set; }

        public long? time_stamp { get; set; }
    }
}
