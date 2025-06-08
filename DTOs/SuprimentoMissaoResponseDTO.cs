namespace GSDrones.DTOs
{
    public class SuprimentoMissaoResponseDTO
    {
        public SuprimentoResponseDTO Suprimento { get; set; }
        public int Quantidade { get; set; }

        public SuprimentoMissaoResponseDTO(SuprimentoResponseDTO suprimentoResponseDTO, int quantidade)
        {
            Suprimento = suprimentoResponseDTO;
            Quantidade = quantidade;
        }
    }
}