﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalcServer.TaskProcessing
{
    /// <summary>
    /// Interfaccia di sola lettura per accedere ad un insieme di contesti di elaborazione, ognuno dei quali è associato
    /// al nome completo ed alla versione della classe che lo implementa.
    /// </summary>
    public interface ITaskPerformerContextProvider
    {
        /// <summary>
        /// L'implementazione di questo metodo deve provare ad ottenere il contesto di elaborazione associato alla classe
        /// specificata, restituendo true se tale classe esiste e pertanto è possibile eseguire il task, altrimenti false
        /// se non esiste e quindi non è possibile eseguire task.
        /// </summary>
        /// <param name="className">nome completo della classe di cui si vuole ottenere il contesto di elaborazione</param>
        /// <param name="classVersion">versione della classe di cui si vuole ottenere il contesto di elaborazione</param>
        /// <param name="context">
        /// Quando termina, questo metodo deve restituire il contesto di elaborazione associato alla classe specificata
        /// nel caso in cui la classe venga trovata; in caso contrario deve restituire il contesto predefinito, che non
        /// esegue alcuna elaborazione.
        /// </param>
        /// <returns>
        /// true, se l'oggetto che implementa l'interfaccia ITaskPerformerContextProvider contiene il contesto cercato per
        /// l'elaborazione e specificato dal nome completo e dalla versione della classe, altrimenti false
        /// </returns>
        bool TryGetContext(string className, string classVersion, out TaskPerformerContext context);

        /// <summary>
        /// Questo metodo dovrebbe controllare se esiste ed è abilitata la risorsa di elaborazione
        /// implementata nella classe specificata, restituendo true se tale classe esiste e quindi
        /// è possibile eseguire il task, altrimenti false se non esiste.
        /// </summary>
        /// <param name="className">nome completo della classe da verificare</param>
        /// <param name="classVersion">versione della classe da verificare</param>
        /// <returns>
        /// true, se l'oggetto che implementa l'interfaccia ITaskPerformerContextProvider contiene
        /// il contesto cercato per l'elaborazione e specificato dal nome completo e dalla versione
        /// della classe, altrimenti false
        /// </returns>
        bool IsResourceEnabled(string className, string classVersion);

        /// <summary>
        /// L'implementazione di questo metodo deve restituire l'insieme di tutti gli identificatori
        /// relativi alle risorse di elaborazione disponibili.
        /// </summary>
        /// <returns>gli identificatori delle risorse di elaborazione disponibili</returns>
        ICollection<string> GetEnabledResources();
    }
}
