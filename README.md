# ARcheology

**ARcheology** é um projeto educacional e interativo em Realidade Aumentada (AR), desenvolvido na Unity, que simula uma experiência imersiva de exploração arqueológica. A aplicação permite aos usuários visualizar, manipular, escanear e armazenar artefatos virtuais integrados ao ambiente real.

## Sobre o Projeto

Este projeto foi desenvolvido como parte do meu processo de aprendizado na trilha de desenvolvimento em AR do **Instituto de Pesquisa Eldorado**, em parceria com a **NexVisual**. Esta implementação corresponde a uma versão espelhada do projeto que desenvolvi ao longo da trilha, cujo projeto original pertence a **Victor Vasconcelos**.

## Visão Geral da Experiência

Utilizando um dispositivo móvel, o usuário pode:

- Detectar superfícies reais para iniciar a experiência em AR
- Explorar artefatos arqueológicos virtuais posicionados no ambiente
- Interagir com os objetos por meio de ações de toque
- Escanear artefatos para desbloquear informações detalhadas
- Armazenar itens descobertos em armários virtuais e pontos específicos

## Funcionalidades Principais

- **Detecção de Planos AR**: Detecção de superfícies horizontais utilizando AR Foundation
- **Interação com Objetos**: Toque para pegar, soltar e inspecionar artefatos
- **Feedback Visual e Animações**: Painéis informativos exibidos de forma contextual

## ⚙️ Tecnologias e Ferramentas

| Categoria | Tecnologias |
|-----------|-------------|
| Engine    | Unity       |
| Linguagem | C#          |

## Como Executar o Projeto

### Passo a Passo

1. Clone ou faça o download deste repositório
2. Abra o projeto no Unity (versão recomendada: 2021.3 ou superior)
3. Conecte um dispositivo compatível com AR (Android/iOS) e faça o build
4. Siga as instruções na tela para iniciar a experiência AR

## Desafios Implementados

### 1. Novas Formas de Interação

**Objetivo**: Exercitar a reutilização de scripts e aprimorar o controle de interações entre diferentes prefabs.

**Implementação**: Foi criada a interface `IInteractionBehaviour` que abriga as funções `OnPickUp` e `OnDrop`, possibilitando criar scripts que determinam as ações executadas quando um objeto é pego ou solto. O `ObjectInteractor` foi modificado para realizar os comportamentos determinados durante as interações.

**Comportamentos criados**:
- Modificar a cor da esfera para vermelho quando ela é segurada.
- Rotacionar o cilindro quando ele não está sendo segurado.

Esses scripts de comportamento foram adicionados aos prefabs dos artefatos mencionados.

### 2. Personalizando o Espaço

**Objetivo**: Desenvolver autonomia na modificação de estruturas 3D e no uso de hierarquias dentro do modelo, criando uma versão única.

**Implementação**: O gabinete foi modificado e, em seu lugar, foi construída uma estante com duas camadas. O `CabinetController` foi adicionado a cada andar para evitar sobreposição de collider boxes.

### 3. Interface e Identidade

**Objetivo**: Compreender melhor a integração entre elementos de UI e interatividade, refinando a comunicação visual da aplicação.

**Implementação**: Foi adicionado um ícone no painel informativo relacionado aos artefatos. Os ícones foram adicionados como parte do `SOObjectInfo` e integrados como Sprites no projeto.

### 4. Explorando Novas Animações

**Objetivo**: Exercitar o uso do Animator e o controle de parâmetros de animação, aprimorando o domínio sobre movimentos e feedbacks visuais.

**Implementação**: O cilindro foi animado de forma que sua altura aumenta e diminui automaticamente sempre que não está sendo segurado.

## Screenshots

###
![](Screenshots/screenshot1.png)

###
![](Screenshots/screenshot2.png)

###
![](Screenshots/screenshot3.png)
