//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldParamOutpObject AsGnrcFieldParamOutp { get; }
}

public interface ItestGnrcFieldParamOutpObject
{
  ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; }
}

public interface ItestRefGnrcFieldParamOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldParamOutpObject<TRef> AsRefGnrcFieldParamOutp { get; }
}

public interface ItestRefGnrcFieldParamOutpObject<TRef>
{
}

public interface ItestAltGnrcFieldParamOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcFieldParamOutpObject AsAltGnrcFieldParamOutp { get; }
}

public interface ItestAltGnrcFieldParamOutpObject
{
  decimal Alt { get; }
}
