public enum StationState
{
    Trabajando = 0,
    HandRaised = 7, // el asesor tiene una duda 
    Preguntando = 60, // pregunta en proceso, el supervisor se acerco y ve la duda
    DudaOk = 5,// duda resuelta correctamente x el jugador 
    DudaMal = 6 // duda resuelta INcorrectamente x el jugador  
}
