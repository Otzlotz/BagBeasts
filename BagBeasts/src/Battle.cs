using System;

public class Battle
{
	public BagBeastObject Player1 { get; set; }

	public BagBeastObject Player2 { get; set; }

	public Battle(BagBeastObject p1, BagBeastObject p2)
	{ 
		Player1 = p1;
		Player2 = p2;
	}

	public void BattleInit(CancellationToken ct)
	{
		while (!ct.IsCancellationRequested)
		{

		}
	}

	public void Select(int movenumm)
	{

	}

	private void Turn(BagBeastObject beast)
	{
		
	}
}
