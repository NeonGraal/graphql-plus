//HintName: test_object-constraint+Output_Intf.gen.cs
// Generated from object-constraint+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

public interface ItestObjCnstOutp<TType>
{
  ItestObjCnstOutpObject AsObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}
