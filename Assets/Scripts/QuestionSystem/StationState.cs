public enum StationState
{
    Trabajando,
    HandRaised, // el asesor tiene una duda 
    Preguntando, // pregunta en proceso, el supervisor se acerco y ve la duda
    DudaOk, // duda resuelta correctamente x el jugador 
    DudaMal // duda resuelta INcorrectamente x el jugador  
}
