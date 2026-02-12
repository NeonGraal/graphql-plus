//HintName: test_object-constraint+Input_Impl.gen.cs
// Generated from object-constraint+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public class testObjCnstInp<TType>
  : ItestObjCnstInp<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
  public ItestObjCnstInpObject<TType> AsObjCnstInp { get; set; }
}
