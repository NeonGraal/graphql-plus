//HintName: test_object-constraint+Input_Intf.gen.cs
// Generated from object-constraint+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public interface ItestObjCnstInp<TType>
{
  ItestObjCnstInpObject AsObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}
