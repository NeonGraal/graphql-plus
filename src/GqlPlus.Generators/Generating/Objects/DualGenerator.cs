namespace GqlPlus.Generating.Objects;

internal sealed class DualInterfaceGenerator()
  : ObjectInterfaceGeneratorBase<IAstDualField>;

internal sealed class DualModelGenerator()
  : ObjectModelGeneratorBase<IAstDualField>;

internal sealed class DualDecoderGenerator()
  : ObjectDecoderGeneratorBase<IAstDualField>;

internal sealed class DualEncoderGenerator()
  : ObjectEncoderGeneratorBase<IAstDualField>;
