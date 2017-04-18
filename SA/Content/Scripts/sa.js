
//Crio uma variável que va guardar os dados do array
var dados = new Array();
var tipoReq = document.getElementById("tprequisicao");
var numReq = document.getElementById("numtpr");
var prd = document.getElementById("produto");
var prdDesc = prd.value.substring(15, prd.value.length);
var qtd = document.getElementById("quantidade");
var qtdEst = 10.00;
var obs = document.getElementById("observacao");
var dep = document.getElementById("departamento");
var cc = document.getElementById("centrocusto");


/*  
 * Atualiza a grid/tabela com os produtos selecionados 
 */
function AtualizaGrid() {

    var tabela = document.getElementById("tbselecionado");
    var textab = "";
    var classe = "";

    for (var i = 0; i <= dados.length - 1; i++) {

        if (dados[i][6] < dados[i][5]) {
            classe = "alert alert-danger";
        } else if (dados[i][6] == dados[i][5]) {
            classe = "alert alert-warning";
        } else {
            classe = "";
        }



        textab += "<tr class='" + classe + "' id='trSolicitacao'" + i + ">"
        textab += "<td id='tdProduto'" + i + ">" + dados[i][4] + "</td>"
        textab += "<td id='tdQuantidadeEstoque'" + i + ">" + dados[i][6] + "</td>"
        textab += "<td id='tdQuantidadeSolicitada'" + i + ">" + dados[i][5] + "</td>"
        textab += "<td id='tdDepartamento'" + i + ">" + dados[i][8] + "</td>"
        textab += "<td id='tdCentrodCusto'" + i + ">" + dados[i][10] + "</td>"
        textab += "<td id='tdEdit'" + i + "><span class='glyphicon glyphicon-wrench'></span></td>"
        textab += "<td id='tdEdit'" + i + "><span class='glyphicon glyphicon-trash'></span></td>"
        textab += "</tr>"

    }

    tabela.outerHTML = '<tbody id="tbselecionado">' + textab + '</tbody>';

}

/*
 *  Monta o array com os produtos selecionados 
 */
function AdicionaArray() {
  

    var aform = new Array(11);

    aform[0] = tipoReq[tipoReq.selectedIndex].textContent; //Pega o elemento selecionado
    aform[1] = tipoReq[tipoReq.selectedIndex].value; //Pega o elemento selecionado
    aform[2] = numReq.value;
    aform[3] = prd.value;
    aform[4] = prdDesc;
    aform[5] = qtd.value;
    aform[6] = qtdEst;
    aform[7] = obs.value;
    aform[8] = dep[dep.selectedIndex].textContent; //Pega o elemento selecionado 
    aform[9] = dep[dep.selectedIndex].value; //Pega o elemento selecionado 
    aform[10] = cc.value;

    dados.push(aform);

    ZeraForm();
}


/*
 * Zera o conteúdo do form após pegar todos os dados 
 */
function ZeraForm() {
    

    numReq.textContent = "";
    prd.textContent = "";
    qtd.textContent = "";
    obs.textContent = "";
    dep.textContent = "";
    cc.textContent = "";
}