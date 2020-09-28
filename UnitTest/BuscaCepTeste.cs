using System;
using FindCep;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class BuscaCepTeste
    {
        /// <summary>
        /// [metodo]_[condigcao]_[resultadoEsperado]
        /// </summary>
        [TestMethod]
        public void PesquisaCepDeveRetornarCepEsperado()
        {
            //Arrange
            BuscaCepRequest buscCep = new BuscaCepRequest();
            string cep = "69050-001";
            BuscaCepResponse response = new BuscaCepResponse();
            //Act
            response = buscCep.Pesquisar(cep.Replace("-",""));
            string cepEsperado = response.Cep;
            //Assert
            Assert.AreEqual(cep, cepEsperado);
        }
    }
}
