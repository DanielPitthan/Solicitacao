

/*  
 * Atualiza a grid/tabela com os produtos selecionados 
 */
function AtualizaGrid(itemSa,index){ //(dados) {

   
    var textab = "";
    var classe = "";
    


   // for (var i = 0; i <= dados.length - 1; i++) {

        //if (dados[i].QuantidadeEstoque < dados[i].QuantidadeSolicitada) {
        //    classe = "alert alert-danger";
        //} else if (dados[i].QuantidadeEstoque == dados[i].QuantidadeSolicitada) {
        //    classe = "alert alert-warning";
        //} else {
        //    classe = "";
        //}



        //textab += "<tr class='" + classe + "' id='trSolicitacao" + i + "'>";
        //textab += "<td id='tdProduto" + i + "'>" + dados[i].DescricaoProduto + "</td>";
        //textab += "<td id='tdQuantidadeEstoque" + i + "'>" + dados[i].QuantidadeEstoque + "</td>";
        //textab += "<td id='tdQuantidadeSolicitada" + i + "'>" + dados[i].QuantidadeSolicitada + "</td>";
        //textab += "<td id='tdDepartamento" + i + "'>" + dados[i].Departamento + "</td>";
        //textab += "<td id='tdCentrodCusto" + i + "'>" + dados[i].CentroCusto + "</td>";
        //textab += "<td id='tdobservacao" + i + "'>" + dados[i].Observacao + "</td>";
        //textab += "<td id='tdEdit" + i + "'><a href='#' id='a1'><span class='glyphicon glyphicon-wrench'></span></a></td>";
        //textab += "<td id='tdEdit" + i + "'><a href='#' onclick='SubtraiArray("+i+")' id='a2'><span class='glyphicon glyphicon-trash'></span></a></td>";
        //textab += "</tr>";

    if (itemSa.QuantidadeEstoque < itemSa.QuantidadeSolicitada) {
            classe = "alert alert-danger";
        } else if (itemSa.QuantidadeEstoque == itemSa.QuantidadeSolicitada) {
            classe = "alert alert-warning";
        } else {
            classe = "";
        }



        textab += "<tr class='" + classe + "' id='trSolicitacao'>";
        textab += "<td id='tdProduto'>" + itemSa.DescricaoProduto + "</td>";
        textab += "<td id='tdQuantidadeEstoque'>" + itemSa.QuantidadeEstoque + "</td>";
        textab += "<td id='tdQuantidadeSolicitada'>" + itemSa.QuantidadeSolicitada + "</td>";
        textab += "<td id='tdDepartamento'>" + itemSa.Departamento + "</td>";
        textab += "<td id='tdCentrodCusto'>" + itemSa.CentroCusto + "</td>";
        textab += "<td id='tdobservacao'>" + itemSa.Observacao + "</td>";
        textab += "<td id='tdEdit'><a href='#' onclick= EditaArray(" + index +")  ><span class='glyphicon glyphicon-wrench'></span></a></td>";
        textab += "<td id='tdEdit'><a href='#' onclick='SubtraiArray(" + index +")' ><span class='glyphicon glyphicon-trash'></span></a></td>";
        textab += "</tr>";

        

    //}

        tabela.innerHTML += textab; // '<tbody id="tbselecionado">' + textab + '</tbody>';

}


function EditaArray(posicao) {
    var trsSolicitacao = document.querySelectorAll("#trSolicitacao");
    trsSolicitacao[posicao].innerHTML = "";
   
                                                                  
    numtpr.value = dados[posicao].NumeroReq;
    prd.value = dados[posicao].CodigoProduto + dados[posicao].DescricaoProduto;
    qtd.value = dados[posicao].QuantidadeSolicitada;
    obs.value = dados[posicao].Observacao;
    dep.value = dados[posicao].DepartamentoValor;
    cc.value = dados[posicao].CentroCusto;


    SubtraiArray(posicao)

}


/**
 * Remove um item da Lista
 * @param {any} posicao
 */
function SubtraiArray(posicao) {
    var trsSolicitacao = document.querySelectorAll("#trSolicitacao");
    trsSolicitacao[posicao].innerHTML = "";
    dados.splice(posicao, 1);
    
}


/*
 *  Monta o array com os produtos selecionados 
 */
function AdicionaArray() {

    var qtdEst = qtdestoque;    
    

    //Verifica se o produto já não foi selecionado
    if (!BuscaProduto(prd.value.substring(0, 15)))
    {
        return;
    }

    //Crio um Item de SA
    var ItemSA = {
        TipoRequisicao: tipoReq[tipoReq.selectedIndex].textContent,
        TipoRequisicaoValor: tipoReq[tipoReq.selectedIndex].value,
        NumeroReq: numtpr.value,
        CodigoProduto: prd.value.substring(0, 15),
        DescricaoProduto: prd.value.substring(15, prd.value.length),
        QuantidadeEstoque: qtdEst,
        QuantidadeSolicitada: qtd.value,
        Departamento: dep[dep.selectedIndex].textContent,
        DepartamentoValor: dep[dep.selectedIndex].value,
        CentroCusto: cc.value,
        Observacao: obs.value
    };        

    dados.push(ItemSA);
    AtualizaGrid(ItemSA, dados.length-1);//(dados);
    ZeraForm();
}




/**
 * Busca se o produto já existe no array de dados
 * @param {any} codprod
 */
function BuscaProduto(codprod)
{
    

    for (var i = 0; i < dados.length; i++) {
        if (dados[i].CodigoProduto == codprod) {

            EscreveAviso("Esse produto já consta na Solicitação");
            return false;
        }

    }
    return true;
}





/**
 * Zera os atributos em tela
 */
function ZeraForm() {    
    quant.placeholder = "";
    qtdestoque = 0;    
    prd.value = "";
    qtd.value = "";
    obs.value = "";
    
}




/**
 * Monta a lista de produtos em tela
 * @param {any} response
 */
function MontaListaProduto(response) {
    var listaHtml = "";
  
        
    for (var i = 0; i < response.lista.length; i++) {
        var texto = response.lista[i].Codigo + response.lista[i].Descricao.trim();
        listaHtml += "<option value='" + texto + "'>";
    }
    listaProduto.innerHTML = ' <datalist id="lstproduto">' + listaHtml + "</datalist>";
}




function AtualizaEstoque(response) {
    if (response.estoque <= 0) {
        quant.className = "alert alert-danger form-control";
        quant.placeholder = "Saldo Insuficiente: " + response.estoque;
    } else {
        quant.placeholder = "Saldo em Estoque: " + response.estoque;
        quant.className = "form-control";
    }
    qtdestoque = response.estoque;

}





/**
 * Escreve o aviso logo após o botão de adicionar
 */
function EscreveAviso(texto) {    
    avisos.innerHTML = '<div id="avisos" class="alert alert-warning">' + texto+'</div>';
}


function LimpaAviso() {
    avisos.innerHTML = '<div id="avisos"></div>';
}



function AvisoModal(titulo,texto) {
    modalTitulo.innerHTML = titulo;
    modalTexto.innerHTML = texto;

    $('#avisomodal').modal('show');    
}