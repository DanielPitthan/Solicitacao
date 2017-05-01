//------------------------------------------------
//Adiciona os enventos no DOM
//------------------------------------------------


//Quantidade 
qtd.addEventListener("blur", ValidaQuantidade);

//Centro de Custo
cc.addEventListener("blur", ValidaMascaraCC);

//Adiciona o Array na pre lista
btAdiciona.addEventListener("click", function () {
    if (TudoValido()) {
        AdicionaArray();
    }
})

//Número da requisição
numtpr.addEventListener("blur", ValidaMascaraNumTpr);
