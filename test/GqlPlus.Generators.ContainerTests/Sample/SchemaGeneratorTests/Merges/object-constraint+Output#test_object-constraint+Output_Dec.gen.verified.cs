//HintName: test_object-constraint+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-constraint+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

public interface ItestObjCnstOutp<TType>
  // No Base because it's Class
{
  ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
  TType Str { get; }
}
