import React from "react";

export default function AboutUs() {
  return (
    <>
      <h2 style={{ marginBottom: "8px" }}> Quem somos </h2>
      <div
        style={{
          marginBottom: "8px",
          display: "flex",
          flexDirection: "column",
          gap: "4px",
        }}
      >
        <p>
          Somos a empresa FERMALOC e desde 2008 atuamos no mercado com a
          prestação de serviços na área de manutenção de máquinas e ferramentas
          elétricas e locação de máquinas.
        </p>
        <p>
          Fornecemos serviços de manutenção em esmerilhadeira, martelete,
          furadeira, serra mármore, inversora de solda e demais ferramentas
          elétricas.
        </p>
        <p>
          Em 2021 a FERMALOC se tornou uma empresa autorizada da MAKITA, podendo
          assim oferecer um serviço de manutenção e venda de peças originais com
          melhor qualidade e preço para seus clientes. E em 2023, nos tornamos
          também autorizada da DEWALT, BLACK & DECKER e STANLEY.
        </p>
        <p>
          Fornecemos também serviços de locação de betoneira, compactador,
          escora, andaime, esmerilhadeira, serra clipper, guincho, roçadeira e
          outras máquinas.
        </p>
        <p>
          Sendo assim, nos colocamos a inteira disposição para prestar-lhes
          serviços especializados de manutenção e/ou locação de máquinas e
          ferramentas na certeza de oferecer-lhes um serviço de qualidade.
        </p>
        <p>Sempre à disposição.</p>
      </div>
      <iframe
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3758.170723883018!2d-44.04823172456286!3d-19.61999762873054!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xa6618551f89a9f%3A0x7c54a99cf097260b!2sFermaloc%20-%20Ferramentas%20El%C3%A9tricas%2C%20M%C3%A1quina%20e%20Loca%C3%A7%C3%A3o!5e0!3m2!1spt-BR!2sbr!4v1710905719512!5m2!1spt-BR!2sbr"
        width="100%"
        height="400"
        allowfullscreen="true"
        loading="lazy"
        referrerpolicy="no-referrer-when-downgrade"
        title="map"
        style={{ border: "none" }}
      ></iframe>
    </>
  );
}
