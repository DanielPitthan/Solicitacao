
/**
 * Valida o tamnho máximo do Centro de Custo
 */
function ValidaMascaraCC() {
    if (cc.value.length > 9) {
        cc.focus();       
        EscreveAviso("Tamanho do Centro de Custo informado é maior 9 dígitos.")
        return false;
    }
    if (!IsNumber(cc.value)) {
        cc.focus();
        EscreveAviso("O valor informado não é um número");
        return false;
    }    
    LimpaAviso();
    return true;
}


/**
 * Valida a quantidade de caracteres digitada no campo numtpr
 */
function ValidaMascaraNumTpr() {
    if (numtpr.value.length > 10) {
        numtpr.focus();
        EscreveAviso("Tamanho do número da Requisição é maior que 10 dígitos");
        return false;
    }

    if (!IsNumber(parseFloat(numtpr.value))) {
        numtpr.focus();
        EscreveAviso("O valor informado não é um número");
        return false;
    }    
    LimpaAviso();
    return true;

}


/**
 * Valida se o centro de custo está preechido
 */
function ValidaCentroCusto() {
    

    if (cc != NaN && cc.value.length > 0) {
        return true;
    }
    return false;
}

/**
 * Valida se o produto foi inserido
 */
function ValidaProduto() {

    if (prd != NaN && prd.value.length > 0 && (prd.value.substring(0, 15).length >= 6 && prd.value.substring(0, 15).length<=15) ) {
        return true;
    }

    return false;
}



/**
 * Valida se a quatidade foi inserida
 */
function ValidaQuantdInsert() {
  
    if (qtd !== NaN && parseFloat(qtd.value) > 0) {
        return true;
    }
    return false;

}



/**
 * Valida se o que foi digitado no campo quantidade é um número
 */
function ValidaQuantidade() {
    var quantidade = parseFloat(qtd.value);

    if (!IsNumber(quantidade)) {
        EscreveAviso("O valor que você informou precisa ser um número");       
        return false;
    }    
    LimpaAviso();
    return true;

}




/**
 * Valida se um argumento é um número
 * @param {any} argumento
 */
function IsNumber(argumento) {
    return result = (!isNaN(argumento));
}





/**
 * Faz todas as validações de campo ao confirmar a pre inclusao 
 */
function TudoValido() {
    if (!ValidaProduto()) {
        EscreveAviso("O código do produto está inválido! Código de produto não existe");
        return false;
    }

    if (!ValidaQuantdInsert()) {
        EscreveAviso("Quantidade não preechida!");
        return false;
    }

    if (!ValidaCentroCusto()) {
        EscreveAviso("Centro de Custo não preechido!");
        return false;
    }

    if (!ValidaMascaraCC()) {
        return false;
    }

    if (!ValidaMascaraNumTpr()) {
        return false;
    }
    LimpaAviso();
    return true;
}