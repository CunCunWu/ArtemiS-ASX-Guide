function calculate_mac_matrix(simulationPch, geometryBdf, measurementHstx, threshold, asxDir)
if nargin < 4 || isempty(threshold)
    threshold = 0.7;
end
if nargin < 5 || isempty(asxDir)
    asxDir = getenv('ASX_DIR');
    if isempty(asxDir)
        asxDir = 'C:\Program Files\HEAD System Integration and Extension (ASX)';
    end
end
if threshold < 0 || threshold > 1
    error('threshold must be between 0 and 1');
end

inputs = {simulationPch, geometryBdf, measurementHstx};
for i = 1:numel(inputs)
    if ~isfile(inputs{i})
        error('Input file not found: %s', inputs{i});
    end
end

NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.License.dll'));
NET.addAssembly(fullfile(asxDir, 'HEADacoustics.API.StructuralAnalysis.ModelUpdating.dll'));

import HEADacoustics.API.License.*;
import HEADacoustics.API.StructuralAnalysis.ModelUpdating.*;

license = License.Create(ProductCode.ASX_10_StructuralAnalysisModelUpdatingAPI);
licenseCleanup = onCleanup(@() license.Dispose()); %#ok<NASGU>

measurementPoints = MeasurementPointsReader.ReadNastran( ...
    simulationPch, geometryBdf, LengthUnit.METER).Wait();
simulationShapes = ShapeTableReader.ReadNastran( ...
    simulationPch, measurementPoints).Wait();
measurementShapes = ShapeTableReader.Read(measurementHstx).Wait();

macMatrix = MacCalculator.CalculateMacMatrix( ...
    simulationShapes, measurementShapes).Wait();
goodPairs = macMatrix.GetValues(threshold);

fprintf('MAC\tSimulationHz\tMeasurementHz\n');
for i = 1:goodPairs.Length
    pair = goodPairs(i);
    fprintf('%.4f\t%.2f\t%.2f\n', ...
        pair.Value, pair.ShapeA.Frequency, pair.ShapeB.Frequency);
end
end
