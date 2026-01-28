using BagBeasts.Data;
using BagBeasts.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BagBeasts.Database;

public static class DbInitializer
{
    public static void Initialize()
    {
        try
        {
            using var context = new BagBeastsContext();
            
            // Ensure database is created
            context.Database.EnsureCreated();

            System.Console.WriteLine("[DEBUG_LOG] Starting seeding...");
            SeedMoves(context);
            System.Console.WriteLine("[DEBUG_LOG] Moves seeded.");
            SeedTypes(context);
            System.Console.WriteLine("[DEBUG_LOG] Types seeded.");
            SeedBeasts(context);
            System.Console.WriteLine("[DEBUG_LOG] Beasts seeded.");
            SeedBbMoves(context);
            System.Console.WriteLine("[DEBUG_LOG] BbMoves seeded.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"[DEBUG_LOG] Error during initialization: {ex.Message}");
            if (ex.InnerException != null)
            {
                System.Console.WriteLine($"[DEBUG_LOG] Inner Exception: {ex.InnerException.Message}");
            }
            throw;
        }
    }

    private static void SeedMoves(BagBeastsContext context)
    {
        if (context.Moves.Any())
        {
            return; // DB has been seeded
        }

        var moves = new List<Move>
        {
            new Move { Id = 0, Name = "Struggle", Description = "meh", Dmg = 0, Acc = 0, CritChanceTier = 0, Pp = 0, Type = 0, Category = 0, Contact = null, Prio = 0 },
            new Move { Id = 1, Name = "Switch", Description = "du hast jetzt augen aids", Dmg = 0, Acc = 0, CritChanceTier = 0, Pp = 0, Type = 0, Category = 0, Contact = null, Prio = 6 },
            new Move { Id = 2, Name = "Return", Description = "Deals Damage", Dmg = 100, Acc = 100, CritChanceTier = 1, Pp = 32, Type = 1, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 3, Name = "Splash", Description = "Sets a random status effect", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 64, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 4, Name = "Waterfall", Description = "Deals Damage and has a chance to make target flinch", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 11, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 5, Name = "Crunch", Description = "Deals Damage and has a chance to lower target defense", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 17, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 6, Name = "Dragon Dance", Description = "Raises Attack and Speed", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 32, Type = 16, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 7, Name = "Avalanche", Description = "Deals Damage", Dmg = 60, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 15, Category = 0, Contact = 1, Prio = -4 },
            new Move { Id = 8, Name = "Iron Head", Description = "Deals Damage and has a chance to make target flinch", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 9, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 9, Name = "Substitute", Description = "Creates a substitute", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 10, Name = "Earthquake", Description = "Deals Damage", Dmg = 100, Acc = 100, CritChanceTier = 1, Pp = 10, Type = 5, Category = 0, Contact = 0, Prio = 0 },
            new Move { Id = 11, Name = "Stone Edge", Description = "Deals Damage with higher Crit chance", Dmg = 100, Acc = 80, CritChanceTier = 2, Pp = 8, Type = 6, Category = 0, Contact = 0, Prio = 0 },
            new Move { Id = 12, Name = "Thunder Wave", Description = "Paralyzes target", Dmg = 0, Acc = 90, CritChanceTier = 0, Pp = 32, Type = 13, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 13, Name = "Dragon Claw", Description = "Deals Damage", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 15, Type = 16, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 14, Name = "Hydro Pump", Description = "Deals Damage", Dmg = 110, Acc = 80, CritChanceTier = 1, Pp = 8, Type = 11, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 15, Name = "Blizzard", Description = "Deals Damage and has a chance to inflict Frostbite", Dmg = 110, Acc = 70, CritChanceTier = 1, Pp = 8, Type = 15, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 16, Name = "Confuse Ray", Description = "Confuses target", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 8, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 17, Name = "Rest", Description = "Restores HP and induces sleep", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 14, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 18, Name = "Sleep Talk", Description = "Uses random move while asleep", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 19, Name = "Thunder", Description = "Deals Damage has a chance to paralyze the target", Dmg = 110, Acc = 70, CritChanceTier = 1, Pp = 16, Type = 13, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 20, Name = "Muddy Water", Description = "Deals Damage", Dmg = 90, Acc = 85, CritChanceTier = 1, Pp = 16, Type = 11, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 21, Name = "Alluring Voice", Description = "Lowers Special Attack", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 15, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 22, Name = "Psychic", Description = "Deals Damage", Dmg = 90, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 14, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 23, Name = "Dragon Pulse", Description = "Deals Damage", Dmg = 85, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 16, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 24, Name = "Shed Tail", Description = "Creates substitute and switches", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 25, Name = "Leaf Blade", Description = "Deals Damage", Dmg = 90, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 12, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 26, Name = "Giga Drain", Description = "Deals Damage and restores HP", Dmg = 75, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 12, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 27, Name = "Leaf Storm", Description = "Deals Damage", Dmg = 130, Acc = 90, CritChanceTier = 1, Pp = 8, Type = 12, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 28, Name = "Endeavor", Description = "Sets Enemy HP to your HP", Dmg = 100, Acc = 100, CritChanceTier = 1, Pp = 8, Type = 1, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 29, Name = "Energy Ball", Description = "Deals Damage", Dmg = 90, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 12, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 30, Name = "X-Scissor", Description = "Deals Damage", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 7, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 31, Name = "Quick Attack", Description = "Deals Damage with priority", Dmg = 40, Acc = 100, CritChanceTier = 1, Pp = 48, Type = 1, Category = 0, Contact = 1, Prio = 1 },
            new Move { Id = 32, Name = "Swords Dance", Description = "Sharply raises Attack", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 32, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 33, Name = "Vacuum Wave", Description = "Deals Damage with priority", Dmg = 40, Acc = 100, CritChanceTier = 1, Pp = 48, Type = 2, Category = 1, Contact = 0, Prio = 1 },
            new Move { Id = 34, Name = "Thunder Punch", Description = "Deals Damage", Dmg = 75, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 13, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 35, Name = "Superpower", Description = "Deals Damage", Dmg = 120, Acc = 100, CritChanceTier = 1, Pp = 8, Type = 2, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 36, Name = "Double-Edge", Description = "Deals Damage with recoil", Dmg = 120, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 1, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 37, Name = "Play Rough", Description = "Deals Damage and can lower enemy defense", Dmg = 90, Acc = 90, CritChanceTier = 1, Pp = 16, Type = 18, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 38, Name = "Trailblaze", Description = "Removes hazards and switches", Dmg = 50, Acc = 100, CritChanceTier = 0, Pp = 32, Type = 1, Category = 12, Contact = 0, Prio = 0 },
            new Move { Id = 39, Name = "Facade", Description = "Deals Damage", Dmg = 70, Acc = 100, CritChanceTier = 1, Pp = 32, Type = 1, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 40, Name = "Ice Spinner", Description = "Deals Damage", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 15, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 41, Name = "Bulldoze", Description = "Deals Damage", Dmg = 60, Acc = 100, CritChanceTier = 1, Pp = 32, Type = 5, Category = 0, Contact = 0, Prio = 0 },
            new Move { Id = 42, Name = "Liquidation", Description = "Deals Damage", Dmg = 85, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 11, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 43, Name = "Protect", Description = "Protects from attacks", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 1, Category = 2, Contact = 0, Prio = 4 },
            new Move { Id = 44, Name = "Knock Off", Description = "Deals Damage and removes item", Dmg = 65, Acc = 100, CritChanceTier = 1, Pp = 32, Type = 17, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 45, Name = "Aqua Jet", Description = "Deals Damage with priority", Dmg = 40, Acc = 100, CritChanceTier = 1, Pp = 32, Type = 11, Category = 0, Contact = 1, Prio = 1 },
            new Move { Id = 46, Name = "Shadow Force", Description = "Deals Damage", Dmg = 120, Acc = 100, CritChanceTier = 1, Pp = 8, Type = 8, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 47, Name = "Destiny Bond", Description = "Deals damage when fainting", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 8, Type = 8, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 48, Name = "Shadow Claw", Description = "Deals Damage", Dmg = 70, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 8, Category = 0, Contact = 1, Prio = 0 },
            new Move { Id = 49, Name = "Hex", Description = "Deals Damage", Dmg = 65, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 8, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 50, Name = "Aura Sphere", Description = "Deals Damage", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 32, Type = 2, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 51, Name = "Earth Power", Description = "Deals Damage", Dmg = 90, Acc = 100, CritChanceTier = 1, Pp = 16, Type = 5, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 52, Name = "Pain Split", Description = "Shares HP with target", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 32, Type = 1, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 53, Name = "Shadow Sneak", Description = "Deals Damage", Dmg = 40, Acc = 100, CritChanceTier = 1, Pp = 48, Type = 8, Category = 0, Contact = 1, Prio = 1 },
            new Move { Id = 54, Name = "Will-O-Wisp", Description = "Burns target", Dmg = 0, Acc = 85, CritChanceTier = 0, Pp = 24, Type = 10, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 55, Name = "Frostbite", Description = "Gives target Frostbite", Dmg = 0, Acc = 90, CritChanceTier = 0, Pp = 24, Type = 15, Category = 2, Contact = 0, Prio = 0 },
            new Move { Id = 56, Name = "Endure", Description = "Protects and restores HP", Dmg = 0, Acc = 100, CritChanceTier = 0, Pp = 16, Type = 1, Category = 2, Contact = 0, Prio = 4 },
            new Move { Id = 57, Name = "Thunderbolt", Description = "Deals Damage", Dmg = 90, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 13, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 58, Name = "Shadow Ball", Description = "Deals Damage", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 8, Category = 1, Contact = 0, Prio = 0 },
            new Move { Id = 59, Name = "Dark Pulse", Description = "Deals Damage", Dmg = 80, Acc = 100, CritChanceTier = 1, Pp = 24, Type = 17, Category = 1, Contact = 0, Prio = 0 }
        };

        context.Moves.AddRange(moves);
        context.SaveChanges();
    }

    private static void SeedTypes(BagBeastsContext context)
    {
        if (context.Types.Any())
        {
            return; // DB has been seeded
        }

        var types = new List<BagBeasts.Entities.Type>
        {
            new BagBeasts.Entities.Type { Id = 0, Name = "Null" },
            new BagBeasts.Entities.Type { Id = 1, Name = "Normal" },
            new BagBeasts.Entities.Type { Id = 2, Name = "Fighting" },
            new BagBeasts.Entities.Type { Id = 3, Name = "Flying" },
            new BagBeasts.Entities.Type { Id = 4, Name = "Poison" },
            new BagBeasts.Entities.Type { Id = 5, Name = "Ground" },
            new BagBeasts.Entities.Type { Id = 6, Name = "Rock" },
            new BagBeasts.Entities.Type { Id = 7, Name = "Bug" },
            new BagBeasts.Entities.Type { Id = 8, Name = "Ghost" },
            new BagBeasts.Entities.Type { Id = 9, Name = "Steel" },
            new BagBeasts.Entities.Type { Id = 10, Name = "Fire" },
            new BagBeasts.Entities.Type { Id = 11, Name = "Water" },
            new BagBeasts.Entities.Type { Id = 12, Name = "Grass" },
            new BagBeasts.Entities.Type { Id = 13, Name = "Electric" },
            new BagBeasts.Entities.Type { Id = 14, Name = "Psycho" },
            new BagBeasts.Entities.Type { Id = 15, Name = "Ice" },
            new BagBeasts.Entities.Type { Id = 16, Name = "Dragon" },
            new BagBeasts.Entities.Type { Id = 17, Name = "Dark" },
            new BagBeasts.Entities.Type { Id = 18, Name = "Fairy" }
        };

        context.Types.AddRange(types);
        context.SaveChanges();
    }

    private static void SeedBeasts(BagBeastsContext context)
    {
        if (context.Beasts.Any())
        {
            return;
        }

        var beasts = new List<Beast>
        {
            new Beast { Id = 129, Name = "Magikarp", Type1 = 11, Type2 = 16, MaxHp = 350, Spa = 171, Def = 238, Spd = 259, Initiative = 261, Atk = 383 },
            new Beast { Id = 131, Name = "Lapras", Type1 = 11, Type2 = 15, MaxHp = 464, Spa = 360, Def = 284, Spd = 250, Initiative = 171, Atk = 226 },
            new Beast { Id = 254, Name = "Gewaldro", Type1 = 12, Type2 = 16, MaxHp = 282, Spa = 389, Def = 186, Spd = 206, Initiative = 427, Atk = 230 },
            new Beast { Id = 184, Name = "Azumarill", Type1 = 11, Type2 = 18, MaxHp = 404, Spa = 140, Def = 197, Spd = 197, Initiative = 136, Atk = 218 },
            new Beast { Id = 201, Name = "Icognito", Type1 = 14, Type2 = 0, MaxHp = 350, Spa = 339, Def = 236, Spd = 189, Initiative = 156, Atk = 372 },
            new Beast { Id = 399, Name = "Bidiza", Type1 = 1, Type2 = 11, MaxHp = 464, Spa = 113, Def = 247, Spd = 196, Initiative = 136, Atk = 416 }
        };

        context.Beasts.AddRange(beasts);
        context.SaveChanges();
    }

    private static void SeedBbMoves(BagBeastsContext context)
    {
        if (context.Bbmoves.Any())
        {
            return;
        }

        var bbMoves = new List<Bbmove>
        {
            // Gewaldro (254)
            new Bbmove { Bbid = 254, MoveId = 6 },
            new Bbmove { Bbid = 254, MoveId = 10 },
            new Bbmove { Bbid = 254, MoveId = 13 },
            new Bbmove { Bbid = 254, MoveId = 23 },
            new Bbmove { Bbid = 254, MoveId = 24 },
            new Bbmove { Bbid = 254, MoveId = 25 },
            new Bbmove { Bbid = 254, MoveId = 26 },
            new Bbmove { Bbid = 254, MoveId = 27 },
            new Bbmove { Bbid = 254, MoveId = 28 },
            new Bbmove { Bbid = 254, MoveId = 29 },
            new Bbmove { Bbid = 254, MoveId = 30 },
            new Bbmove { Bbid = 254, MoveId = 31 },
            new Bbmove { Bbid = 254, MoveId = 32 },
            new Bbmove { Bbid = 254, MoveId = 33 },
            new Bbmove { Bbid = 254, MoveId = 34 },
            new Bbmove { Bbid = 254, MoveId = 0 },
            new Bbmove { Bbid = 254, MoveId = 1 },

            // Bidiza (399)
            new Bbmove { Bbid = 399, MoveId = 0 },
            new Bbmove { Bbid = 399, MoveId = 1 },
            new Bbmove { Bbid = 399, MoveId = 2 },
            new Bbmove { Bbid = 399, MoveId = 4 },
            new Bbmove { Bbid = 399, MoveId = 5 },
            new Bbmove { Bbid = 399, MoveId = 7 },
            new Bbmove { Bbid = 399, MoveId = 8 },
            new Bbmove { Bbid = 399, MoveId = 9 },
            new Bbmove { Bbid = 399, MoveId = 12 },
            new Bbmove { Bbid = 399, MoveId = 31 },
            new Bbmove { Bbid = 399, MoveId = 32 },
            new Bbmove { Bbid = 399, MoveId = 35 },
            new Bbmove { Bbid = 399, MoveId = 36 },
            new Bbmove { Bbid = 399, MoveId = 37 },
            new Bbmove { Bbid = 399, MoveId = 39 },
            new Bbmove { Bbid = 399, MoveId = 41 },
            new Bbmove { Bbid = 399, MoveId = 45 }
        };

        context.Bbmoves.AddRange(bbMoves);
        context.SaveChanges();
    }
}
