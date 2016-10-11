using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;
using BIO.Framework.Core.Template;

namespace BIO.Framework.Extensions.Standard.Block {
    public interface IInputDataProcessingBlockComponents <
        TInputData,
        TEvaluatedFeatureVector,
        TTemplate,
        TTemplatedFeatureVector
    > 
        where TInputData : BIO.Framework.Core.InputData.IInputData
        where TTemplatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TEvaluatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TTemplate : BIO.Framework.Core.Template.ITemplate<TTemplatedFeatureVector>
        
    {
        //Tempalted feature vector extractor
        IFeatureVectorExtractor<TInputData, TTemplatedFeatureVector> getTemplatedFeatureVectorExtractor();

        //Evaluation feature vector extractor
        IFeatureVectorExtractor<TInputData, TEvaluatedFeatureVector> getEvaluationFeatureVectorExtractor();

        //comparator
        IComparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> getComparator();

        //template creator 
        ITemplateCreator<TTemplatedFeatureVector, TTemplate> getTemplateCreator();

        //TODO remove - just for fast prototyping
        Core.Block.IInputDataProcessingBlock<TInputData> createBlock();
    }
        
    
}
