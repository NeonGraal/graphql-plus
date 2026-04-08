//HintName: test_object-constraint+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-constraint+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public interface ItestObjCnstInp<TType>
  // No Base because it's Class
{
  ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
  TType Str { get; }
}
