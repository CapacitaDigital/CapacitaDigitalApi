using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapacitaDigitalApi.Enums;

namespace CapacitaDigitalApi.Models
{
    public class Content
    {
        public int Id { get; set; } // Id do conteúdo
        public string Title { get; set; } // Título do conteúdo
        public string? Description { get; set; } // Descrição do conteúdo
        public ContentType Type { get; set; } // Tipo de conteúdo (aula ou exercício)
        public string? UrlImage { get; set; } // URL da imagem
        public string? UrlVideo { get; set; } // URL do vídeo
        public List<string>? UrlsDocuments { get; set; } // Lista de URLs de documentos
        public string ActivityData { get; set; } // Dados da atividade 
        public int ModuleId { get; set; } // Propriedade para a chave estrangeira do módulo que contém o conteúdo

    }
}