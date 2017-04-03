﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Plant {
	public abstract string Species { get; }

	// Amount of ticks into production cycle we are
	private int Cycle { get; set; }
	// A list of Foods/quantities produced, paired with the production rate (number of ticks)
	public abstract List<KeyValuePair<KeyValuePair<Food, int>, int>> FoodList { get; }

	// public abstract int Shade { get; }

	public void DoTick(object environment) {
		++Cycle;
		// Get a list of the food/counts we need to make
		var produce = FoodList.Where(f => Cycle % f.Value == 0).Select(f => f.Key).ToList();

		foreach (KeyValuePair<Food, int> food in produce) {
			//environment.AddFood(food.Key, food.Value);
		}

		// Every time we've added everything, reset our cycle
		if (produce.Count == FoodList.Count) {
			Cycle = 0;
		}
	}
}
	