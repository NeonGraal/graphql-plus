//HintName: test_object-constraint+Output_Intf.gen.cs
// Generated from object-constraint+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

public interface ItestObjCnstOutp<Ttype>
{
  ItestObjCnstOutpObject AsObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<Ttype>
{
  Ttype Field { get; }
  Ttype Str { get; }
}
