using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BIO.Framework.Core;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;
using BIO.Framework.Core.Template;
using BIO.Framework.Extensions.Standard.Template;

namespace BIO.Framework.Extensions.Standard.Block {
    /// <summary>
    /// settings of internal components of block
    /// </summary>
    /// <typeparam name="TInputData">input data</typeparam>
    /// <typeparam name="TEvaluatedFeatureVector"></typeparam>
    /// <typeparam name="TTemplate"></typeparam>
    /// <typeparam name="TTemplatedFeatureVector"></typeparam>
    public abstract class InputDataProcessingBlockSettings <
        TInputData,
        TEvaluatedFeatureVector,
        TTemplate,
        TTemplatedFeatureVector
    > : IInputDataProcessingBlockComponents<
        TInputData,
        TEvaluatedFeatureVector,
        TTemplate,
        TTemplatedFeatureVector
    >
        where TInputData : BIO.Framework.Core.InputData.IInputData
        where TTemplatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TEvaluatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TTemplate : BIO.Framework.Core.Template.ITemplate<TTemplatedFeatureVector>, new()
        
    {

        private string name;

        public InputDataProcessingBlockSettings(string name) {
            this.name = name;
        }

        //Tempalted feature vector extractor

        IFeatureVectorExtractor<TInputData, TTemplatedFeatureVector> templatedExtractor = null;

        public IFeatureVectorExtractor<TInputData, TTemplatedFeatureVector> getTemplatedFeatureVectorExtractor() {
            if (this.templatedExtractor == null){
                this.templatedExtractor = this.createTemplatedFeatureVectorExtractor();
            }
            return templatedExtractor;
        }

        protected abstract IFeatureVectorExtractor<TInputData, TTemplatedFeatureVector> createTemplatedFeatureVectorExtractor();

        //Evaluation feature vector extractor

        IFeatureVectorExtractor<TInputData, TEvaluatedFeatureVector> evaluationExtractor = null;

        public IFeatureVectorExtractor<TInputData, TEvaluatedFeatureVector> getEvaluationFeatureVectorExtractor() {
            if (this.evaluationExtractor == null) {
                this.evaluationExtractor = this.createEvaluationFeatureVectorExtractor();
            }
            return evaluationExtractor;
        }

        protected abstract IFeatureVectorExtractor<TInputData, TEvaluatedFeatureVector> createEvaluationFeatureVectorExtractor();

        //Comparator
        IComparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> comparator = null;

        public IComparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> getComparator() {
            if (this.comparator == null) {
                this.comparator = this.createComparator();
            }
            return comparator;
        }

        protected abstract IComparator<TEvaluatedFeatureVector, TTemplate, TTemplatedFeatureVector> createComparator();


        ITemplateCreator<TTemplatedFeatureVector, TTemplate> templateCreator = null;

        public ITemplateCreator<TTemplatedFeatureVector, TTemplate> getTemplateCreator() {
            if (this.templateCreator == null) {
                this.templateCreator = this.createTemplateCreator();
            }
            return templateCreator;
        }

        /// <summary>
        /// can be overriden
        /// </summary>
        /// <returns></returns>
        protected virtual ITemplateCreator<TTemplatedFeatureVector, TTemplate> createTemplateCreator() {
            return new TemplateCreator<TTemplatedFeatureVector, TTemplate>();
        }


        public Core.Block.IInputDataProcessingBlock<TInputData> createBlock() {
            return new InputDataProcessingBlock<
                TInputData,
                TEvaluatedFeatureVector,
                TTemplate,
                TTemplatedFeatureVector>(this, this.name);
        }

        
    }

    /// <summary>
    /// shortcut for InputDataProcessingBlockSettings
    /// TTemplate is Standard.Template
    /// </summary>
    /// <typeparam name="TInputData"></typeparam>
    /// <typeparam name="TEvaluatedFeatureVector"></typeparam>
    /// <typeparam name="TTemplatedFeatureVector"></typeparam>
    public abstract class InputDataProcessingBlockSettings<
        TInputData,
        TEvaluatedFeatureVector,
        TTemplatedFeatureVector
    > : InputDataProcessingBlockSettings<
        TInputData,
        TEvaluatedFeatureVector,
        Template<TTemplatedFeatureVector>,
        TTemplatedFeatureVector
    >
        where TInputData : BIO.Framework.Core.InputData.IInputData
        where TTemplatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        where TEvaluatedFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
        {
        public InputDataProcessingBlockSettings(string name)
            : base(name) {
            //this.name = name;
        }
    }

    /// <summary>
    /// shortcut for InputDataProcessingBlockSettings
    /// TTemplate is Standard.Template
    /// Extracted FeatureVector and Evaluated feature vector has same type
    /// </summary>
    /// <typeparam name="TInputData"></typeparam>
    /// <typeparam name="TFeatureVector"></typeparam>
    public abstract class InputDataProcessingBlockSettings<
        TInputData,
        TFeatureVector
    > : InputDataProcessingBlockSettings<
        TInputData,
        TFeatureVector,
        Template<TFeatureVector>,
        TFeatureVector
    >
        where TInputData : BIO.Framework.Core.InputData.IInputData
        where TFeatureVector : BIO.Framework.Core.FeatureVector.IFeatureVector
    {
        public InputDataProcessingBlockSettings(string name) : base(name) {
         
        }

        protected abstract Framework.Core.FeatureVector.IFeatureVectorExtractor<TInputData, TFeatureVector> createFeatureVectorExtractor();


        protected override Framework.Core.FeatureVector.IFeatureVectorExtractor<TInputData, TFeatureVector> createTemplatedFeatureVectorExtractor() {
            return this.createFeatureVectorExtractor();
        }
        protected override Framework.Core.FeatureVector.IFeatureVectorExtractor<TInputData, TFeatureVector> createEvaluationFeatureVectorExtractor() {
            return this.createFeatureVectorExtractor();
        }
    }    
}
