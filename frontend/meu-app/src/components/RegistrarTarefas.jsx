import { useState } from "react";

export default function RegistrarTarefas({ aoAdicionar }) {
  const [nome, setNome] = useState("");
  const [description, setDescription] = useState("");

  const adicionarTarefa = async (e) => {
    e.preventDefault();

    // Validação simples para não enviar vazio
    if (!nome.trim()) return;

    const novaTarefaObj = {
      name: nome,
      description: description,
      priority: "Normal",
      dueDate: new Date().toISOString(),
      status: "2",
    };

    try {
      const resposta = await fetch("https://localhost:7283/api/ToDoList", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(novaTarefaObj),
      });

      if (resposta.ok) {
        const tarefaCriada = await resposta.json();
        aoAdicionar(tarefaCriada);
        setNome("");
        setDescription("");

        // Opcional: Colocar o foco de volta no input de nome
        // document.getElementById("input-nome").focus();
      }
    } catch (erro) {
      console.error("Erro ao adicionar", erro);
    }
  };

  return (
    /* Aplicamos a classe form-caderno */
    <form onSubmit={adicionarTarefa} className="form-caderno">
      {/* Removemos o H2 para não quebrar a imersão */}

      {/* Input 1: Nome da Tarefa */}
      <input
        id="input-nome"
        className="input-caderno" /* Classe nova */
        value={nome}
        onChange={(e) => setNome(e.target.value)}
        required
        placeholder="🖊️ Escreva uma nova tarefa..."
        autoComplete="off"
      />

      {/* Input 2: Descrição (Opcional: se quiser que pareça um subtítulo) */}
      <input
        className="input-caderno"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="... detalhe extra (opcional)"
        autoComplete="off"
        style={{
          fontSize: "24px",
          color: "#555",
        }} /* Um pouco menor para diferenciar */
      />

      {/* Botão escondido apenas para permitir submit com "Enter" */}
      <button type="submit" className="btn-escondido">
        Adicionar
      </button>
    </form>
  );
}
