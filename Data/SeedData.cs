using GestaoTorneiosEsports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GestaoTorneiosEsports.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context
            )
        {
            
            {
                // Verifica se já existem torneios no banco
                if (context.Torneios.Any())
                {
                    return; // O banco já foi populado
                }

                // Adiciona torneios de exemplo
                var torneios = new Torneio[]
                {
                    new Torneio

                    {
                        Nome = "Worlds 2025",
                        Jogo = "League of Legends",
                        DataInicio = new DateTime(2025, 6, 15),
                        DataFim = new DateTime(2025, 7, 10),
                        PremioTotal = 100000.00M,
                        Descricao = "Campeonato mundial com as melhores equipes."
                    },
                    new Torneio
                    {
                        Nome = "Major ESL",
                        Jogo = "Counter-Strike 2",
                        DataInicio = new DateTime(2025, 8, 1),
                        DataFim = new DateTime(2025, 8, 15),
                        PremioTotal = 75000.00M,
                        Descricao = "Torneio premium com as equipes de elite."
                    },
                    new Torneio
                    {
                        Nome = "Rocket Championship",
                        Jogo = "Rocket League",
                        DataInicio = new DateTime(2025, 9, 5),
                        DataFim = new DateTime(2025, 9, 12),
                        PremioTotal = 50000.00M,
                        Descricao = "Competição de alta velocidade."
                    },
                    new Torneio
                    {
                        Nome = "Battle Royale Invitational",
                        Jogo = "Fortnite",
                        DataInicio = new DateTime(2025, 7, 20),
                        DataFim = new DateTime(2025, 7, 22),
                        PremioTotal = 60000.00M,
                        Descricao = "Torneio por convite para os melhores jogadores."
                    }
                };

                foreach (Torneio torneio in torneios) { 
                context.Torneios.AddRange(torneios);
                context.SaveChanges();
                }

                // Adiciona equipes de exemplo
                var equipes = new Equipe[]
                {
                    // Equipes para League of Legends
                    new Equipe
                    {
                        Nome = "Furia",
                        Tag = "FUR",
                        NumeroJogadores = 5,
                        Pais = "Brasil",
                        Pontuacao = 92,
                        TorneioId = torneios[0].TorneioId
                    },
                    new Equipe
                    {
                        Nome = "T1",
                        Tag = "T1",
                        NumeroJogadores = 5,
                        Pais = "Coreia do Sul",
                        Pontuacao = 95,
                        TorneioId = torneios[0].TorneioId
                    },
                    new Equipe
                    {
                        Nome = "Loud",
                        Tag = "LLL",
                        NumeroJogadores = 5,
                        Pais = "Brasil",
                        Pontuacao = 88,
                        TorneioId = torneios[0].TorneioId
                    },
                    
                    // Equipes para Counter-Strike 2
                    new Equipe
                    {
                        Nome = "SKT",
                        Tag = "SKT",
                        NumeroJogadores = 5,
                        Pais = "Brasil",
                        Pontuacao = 90,
                        TorneioId = torneios[1].TorneioId
                    },
                    new Equipe
                    {
                        Nome = "Natus Vincere",
                        Tag = "NaVi",
                        NumeroJogadores = 5,
                        Pais = "Ucrânia",
                        Pontuacao = 93,
                        TorneioId = torneios[1].TorneioId
                    },
                    
                    // Equipes para Rocket League
                    new Equipe
                    {
                        Nome = "Team Liquid",
                        Tag = "TL",
                        NumeroJogadores = 3,
                        Pais = "Estados Unidos",
                        Pontuacao = 85,
                        TorneioId = torneios[2].TorneioId
                    },
                    new Equipe
                    {
                        Nome = "NRG Esports",
                        Tag = "NRG",
                        NumeroJogadores = 3,
                        Pais = "Estados Unidos",
                        Pontuacao = 87,
                        TorneioId = torneios[2].TorneioId
                    },
                    
                    // Equipes para Fortnite
                    new Equipe
                    {
                        Nome = "100 Thieves",
                        Tag = "100T",
                        NumeroJogadores = 4,
                        Pais = "Estados Unidos",
                        Pontuacao = 82,
                        TorneioId = torneios[3].TorneioId
                    },
                    new Equipe
                    {
                        Nome = "TSM",
                        Tag = "TSM",
                        NumeroJogadores = 4,
                        Pais = "Estados Unidos",
                        Pontuacao = 84,
                        TorneioId = torneios[3].TorneioId
                    }
                };
                foreach    (Equipe equipe in equipes) { 
                context.Equipes.AddRange(equipes);
                context.SaveChanges();
                }
            }
        }
    }
}