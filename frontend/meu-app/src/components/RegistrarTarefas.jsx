import { useState } from "react";

export default function RegistrarTarefas({ aoAdicionar }) {
  const [nome, setNome] = useState("");
  const [description, setDescription] = useState("");

  const adicionarTarefa = async (e) => {
    e.preventDefault();

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
      }
    } catch (erro) {
      console.error("Erro ao adicionar", erro);
    }
  };

  return (
    <form onSubmit={adicionarTarefa} className="form-caderno">
      <input
        id="input-nome"
        className="input-caderno"
        value={nome}
        onChange={(e) => setNome(e.target.value)}
        required
        placeholder="🖊️ Escreva uma nova tarefa..."
        autoComplete="off"
      />

      <input
        className="input-caderno"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="... detalhe extra (opcional)"
        autoComplete="off"
        style={{
          fontSize: "24px",
          color: "#555",
        }}
      />

      <button type="submit" className="btn-escondido">
        Adicionar
      </button>
    </form>
  );
}
