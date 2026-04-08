//HintName: test_constraint-field-obj+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
{
  ItestCnstFieldObjOutpObject? As_CnstFieldObjOutp { get; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>
{
}

public interface ItestRefCnstFieldObjOutp<TRef>
  // No Base because it's Class
{
  ItestRefCnstFieldObjOutpObject<TRef>? As_RefCnstFieldObjOutp { get; }
}

public interface ItestRefCnstFieldObjOutpObject<TRef>
  // No Base because it's Class
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstFieldObjOutpObject? As_PrntCnstFieldObjOutp { get; }
}

public interface ItestPrntCnstFieldObjOutpObject
  // No Base because it's Class
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  ItestAltCnstFieldObjOutpObject? As_AltCnstFieldObjOutp { get; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  decimal Alt { get; }
}
