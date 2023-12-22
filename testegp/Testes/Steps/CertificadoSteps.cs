using System;
using TechTalk.SpecFlow;

namespace Testes.Steps
{
    [Binding]
    public class CertificadoSteps
    {
        [When(@"eu adiciono um certificado com os detalhes")]
        public void WhenEuAdicionoUmCertificadoComOsDetalhes()
        {          
            Console.WriteLine("Adicionando um certificado com os detalhes...");
        }

        [Then(@"o certificado é adicionado com sucesso")]
        public void ThenOCertificadoEAdicionadoComSucesso()
        {
            Console.WriteLine("Certificado adicionado com sucesso!");
        }
    }
}
